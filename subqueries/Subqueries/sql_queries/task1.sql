SELECT p.id, pt.title AS product, p.price
FROM product p
INNER JOIN product_title pt ON pt.id = p.product_title_id
WHERE p.price >= 2 * (SELECT MIN(price) FROM product)
ORDER BY p.price ASC, product ASC
