SELECT
    p.surname AS surname,
    p.name AS name,
    COALESCE(SUM(od.price_with_discount * od.product_amount), 0) AS sum
FROM customer c
INNER JOIN person p ON p.id = c.person_id
LEFT JOIN customer_order co ON co.customer_id = c.person_id
LEFT JOIN order_details od ON od.customer_order_id = co.id
GROUP BY p.id, p.surname, p.name

UNION

SELECT
    NULL AS surname,
    NULL AS name,
    SUM(od.price_with_discount * od.product_amount) AS sum
FROM customer_order co
LEFT JOIN order_details od ON od.customer_order_id = co.id
WHERE co.customer_id IS NULL

ORDER BY sum ASC, surname ASC;
