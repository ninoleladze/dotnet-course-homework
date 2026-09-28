namespace NumberTheory;

public static class SieveOfEratosthenes
{
    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using a sequential approach.
    /// </summary>
    public static IEnumerable<int> GetPrimeNumbersSequentialAlgorithm(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        bool[] isComposite = new bool[n + 1];

        for (int m = 2; (long)m * m <= n; m++)
        {
            if (isComposite[m])
            {
                continue;
            }

            for (int multiple = m * m; multiple <= n; multiple += m)
            {
                isComposite[multiple] = true;
            }
        }

        return Enumerable.Range(2, n - 1).Where(i => !isComposite[i]);
    }

    /// <summary>
    /// Generates a sequence of prime numbers up to the specified limit using a modified sequential approach.
    /// Two-stage: first find base primes up to sqrt(n), then sieve the rest.
    /// </summary>
    public static IEnumerable<int> GetPrimeNumbersModifiedSequentialAlgorithm(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        int sqrtN = (int)Math.Sqrt(n);

        // Stage 1: find base primes up to sqrt(n) using classical sieve
        bool[] baseComposite = new bool[sqrtN + 1];
        for (int m = 2; (long)m * m <= sqrtN; m++)
        {
            if (baseComposite[m])
            {
                continue;
            }

            for (int multiple = m * m; multiple <= sqrtN; multiple += m)
            {
                baseComposite[multiple] = true;
            }
        }

        int[] basePrimes = Enumerable.Range(2, sqrtN - 1).Where(i => !baseComposite[i]).ToArray();

        // Stage 2: sieve range (sqrtN, n] using base primes
        bool[] isComposite = new bool[n + 1];

        foreach (int p in basePrimes)
        {

            // First multiple of p that is > sqrtN
            int start = ((sqrtN / p) + 1) * p;
            if (start < p * p)
            {
                start = p * p;
            }

            for (int multiple = start; multiple <= n; multiple += p)
            {
                isComposite[multiple] = true;
            }
        }

        // Combine: base primes + primes found in stage 2
        var stage2Primes = Enumerable.Range(sqrtN + 1, n - sqrtN).Where(i => !isComposite[i]);
        return basePrimes.Concat(stage2Primes);
    }

    /// <summary>
    /// Generates prime numbers using concurrent data decomposition.
    /// Partitions the range [sqrt(n), n] into equal parts, each processed by a separate thread.
    /// </summary>
    public static IEnumerable<int> GetPrimeNumbersConcurrentDataDecomposition(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        int sqrtN = (int)Math.Sqrt(n);

        // Stage 1: sequential base primes
        bool[] baseComposite = new bool[sqrtN + 1];
        for (int m = 2; (long)m * m <= sqrtN; m++)
        {
            if (baseComposite[m])
            {
                continue;
            }

            for (int multiple = m * m; multiple <= sqrtN; multiple += m)
            {
                baseComposite[multiple] = true;
            }
        }

        int[] basePrimes = Enumerable.Range(2, sqrtN - 1).Where(i => !baseComposite[i]).ToArray();

        // Stage 2: parallel data decomposition
        bool[] isComposite = new bool[n + 1];
        int threadCount = Environment.ProcessorCount;
        int rangeSize = (n - sqrtN + threadCount - 1) / threadCount;

        Thread[] threads = new Thread[threadCount];
        for (int t = 0; t < threadCount; t++)
        {
            int rangeStart = sqrtN + 1 + t * rangeSize;
            int rangeEnd = Math.Min(rangeStart + rangeSize - 1, n);

            if (rangeStart > n)
            {
                break;
            }

            threads[t] = new Thread(() =>
            {
                foreach (int p in basePrimes)
                {

                    // First multiple of p in [rangeStart, rangeEnd]
                    int start = ((rangeStart - 1) / p + 1) * p;
                    if (start < p * 2)
                    {
                        start = p * 2;
                    }

                    for (int multiple = start; multiple <= rangeEnd; multiple += p)
                    {
                        isComposite[multiple] = true;
                    }
                }
            });
            threads[t].Start();
        }

        foreach (var thread in threads)
        {
            thread?.Join();
        }

        var stage2Primes = Enumerable.Range(sqrtN + 1, n - sqrtN).Where(i => !isComposite[i]);
        return basePrimes.Concat(stage2Primes);
    }

    /// <summary>
    /// Generates prime numbers using concurrent basic primes decomposition.
    /// Each thread handles a subset of base primes and sieves the full range.
    /// </summary>
    public static IEnumerable<int> GetPrimeNumbersConcurrentBasicPrimesDecomposition(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        int sqrtN = (int)Math.Sqrt(n);

        // Stage 1: sequential base primes
        bool[] baseComposite = new bool[sqrtN + 1];
        for (int m = 2; (long)m * m <= sqrtN; m++)
        {
            if (baseComposite[m])
            {
                continue;
            }

            for (int multiple = m * m; multiple <= sqrtN; multiple += m)
            {
                baseComposite[multiple] = true;
            }
        }

        int[] basePrimes = Enumerable.Range(2, sqrtN - 1).Where(i => !baseComposite[i]).ToArray();

        // Stage 2: each thread processes a chunk of base primes over the full range
        bool[] isComposite = new bool[n + 1];
        int threadCount = Math.Min(Environment.ProcessorCount, basePrimes.Length);
        if (threadCount == 0)
        {
            return basePrimes.Concat(Enumerable.Range(sqrtN + 1, n - sqrtN).Where(i => !isComposite[i]));
        }

        int chunkSize = (basePrimes.Length + threadCount - 1) / threadCount;
        Thread[] threads = new Thread[threadCount];

        for (int t = 0; t < threadCount; t++)
        {
            int from = t * chunkSize;
            int to = Math.Min(from + chunkSize, basePrimes.Length);

            threads[t] = new Thread(() =>
            {
                for (int pi = from; pi < to; pi++)
                {
                    int p = basePrimes[pi];
                    int start = sqrtN + 1;

                    // Align to first multiple of p >= start
                    int rem = start % p;
                    if (rem != 0)
                    {
                        start += p - rem;
                    }

                    for (int multiple = start; multiple <= n; multiple += p)
                    {
                        isComposite[multiple] = true;
                    }
                }
            });
            threads[t].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        var stage2Primes = Enumerable.Range(sqrtN + 1, n - sqrtN).Where(i => !isComposite[i]);
        return basePrimes.Concat(stage2Primes);
    }

    /// <summary>
    /// Generates prime numbers using a thread pool with a signaling construct (CountdownEvent).
    /// Each work item checks divisibility by one base prime across the full upper range.
    /// </summary>
    public static IEnumerable<int> GetPrimeNumbersConcurrentWithThreadPool(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
        }

        int sqrtN = (int)Math.Sqrt(n);

        // Stage 1: sequential base primes
        bool[] baseComposite = new bool[sqrtN + 1];
        for (int m = 2; (long)m * m <= sqrtN; m++)
        {
            if (baseComposite[m])
            {
                continue;
            }

            for (int multiple = m * m; multiple <= sqrtN; multiple += m)
            {
                baseComposite[multiple] = true;
            }
        }

        int[] basePrimes = Enumerable.Range(2, sqrtN - 1).Where(i => !baseComposite[i]).ToArray();

        // Stage 2: thread pool — one work item per base prime
        bool[] isComposite = new bool[n + 1];

        if (basePrimes.Length == 0)
        {
            return Enumerable.Range(2, n - 1).Where(i => !isComposite[i]);
        }

        using CountdownEvent countdown = new CountdownEvent(basePrimes.Length);

        foreach (int prime in basePrimes)
        {
            int p = prime;

            // capture for closure
            ThreadPool.QueueUserWorkItem(_ =>
            {
                int start = sqrtN + 1;
                int rem = start % p;
                if (rem != 0)
                {
                    start += p - rem;
                }

                for (int multiple = start; multiple <= n; multiple += p)
                {
                    isComposite[multiple] = true;
                }

                countdown.Signal();
            });
        }

        countdown.Wait();

        var stage2Primes = Enumerable.Range(sqrtN + 1, n - sqrtN).Where(i => !isComposite[i]);
        return basePrimes.Concat(stage2Primes);
    }
}
