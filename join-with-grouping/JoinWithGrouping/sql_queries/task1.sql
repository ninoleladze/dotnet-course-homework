SELECT pc.name AS category,
       COUNT(p.id) AS count
FROM product_category pc
INNER JOIN product_title pt ON pt.product_category_id = pc.id
INNER JOIN product p ON p.product_title_id = pt.id
GROUP BY pc.id, pc.name
ORDER BY pc.name ASC;
