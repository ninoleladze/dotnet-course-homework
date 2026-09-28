SELECT product.id AS id,
       product_title.title AS title,
       product.price AS price
FROM product
INNER JOIN product_title ON product.product_title_id = product_title.id
ORDER BY product_title.title ASC;
