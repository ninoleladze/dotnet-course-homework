SELECT c.name AS city,
       SUM(od.price_with_discount * od.product_amount) AS income
FROM city c
INNER JOIN street s ON s.city_id = c.id
INNER JOIN supermarket sm ON sm.street_id = s.id
INNER JOIN customer_order co ON co.supermarket_id = sm.id
INNER JOIN order_details od ON od.customer_order_id = co.id
WHERE co.operation_time BETWEEN '2020-11-01' AND '2020-11-30'
GROUP BY c.id, c.name
ORDER BY income ASC, c.name ASC;
