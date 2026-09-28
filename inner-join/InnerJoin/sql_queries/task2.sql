SELECT product.id AS id,
       product_title.title AS title,
       product_category.name AS category,
       product.price AS price
FROM product
INNER JOIN product_title ON product.product_title_id = product_title.id
INNER JOIN product_category ON product_title.product_category_id = product_category.id
ORDER BY product_category.name ASC, product_title.title ASC;
