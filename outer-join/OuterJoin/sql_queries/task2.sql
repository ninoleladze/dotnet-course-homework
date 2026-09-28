SELECT
    p.surname AS surname,
    p.name AS name,
    p.birth_date AS birth_date
FROM customer c
INNER JOIN person p ON p.id = c.person_id
LEFT JOIN customer_order co ON co.customer_id = c.person_id
WHERE co.id IS NULL
ORDER BY p.surname ASC, p.birth_date ASC;
