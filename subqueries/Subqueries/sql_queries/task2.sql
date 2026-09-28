SELECT per.surname, per.name, SUM(od.price_with_discount * od.product_amount) AS total_expenses
FROM person per
JOIN customer c ON c.person_id = per.id
JOIN customer_order co ON co.customer_id = c.person_id
JOIN order_details od ON od.customer_order_id = co.id
WHERE per.birth_date BETWEEN '2000-01-01' AND '2010-12-31'
GROUP BY per.id
HAVING SUM(od.price_with_discount * od.product_amount) > (
    SELECT AVG(customer_total)
    FROM (
        SELECT SUM(od2.price_with_discount * od2.product_amount) AS customer_total
        FROM customer_order co2
        JOIN order_details od2 ON od2.customer_order_id = co2.id
        WHERE co2.customer_id IS NOT NULL
        GROUP BY co2.customer_id
    ) sub
)
ORDER BY total_expenses ASC, per.surname ASC
