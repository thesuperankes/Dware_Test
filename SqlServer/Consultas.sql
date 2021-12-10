/*Precio de todos los productos*/
SELECT price
FROM   tbl_product
/*Productos con minimo de 5 unidades*/
SELECT [name],
       quantity,
       price,
       creationdate
FROM   tbl_product
WHERE  quantity < 5

/*CLientes no mayores a 35 años*/
SELECT *
FROM   tbl_order O
       INNER JOIN tbl_client c
               ON c.clientid = O.clientid
                  AND Cast(c.age AS INT) <= 35
WHERE  o.purchasedate > '2000-02-01'
       AND O.purchasedate < '2000-05-25'
/*Valor total vendido en el año 2000*/
SELECT o.purchasedate,
       P.[name],
       P.price
FROM   tbl_order o
       INNER JOIN tbl_productorder PO
               ON o.orderid = PO.orderid
       INNER JOIN tbl_product P
               ON P.productid = PO.productid
WHERE  o.purchasedate > '2000-01-01'
       AND O.purchasedate < '2000-12-31'

/*Frecuencia de compra*/
SELECT Dateadd(day, ( Datediff(day, (SELECT TOP 1 purchasedate
                                     FROM   tbl_order
                                     WHERE  clientid = 1
                                     ORDER  BY purchasedate ASC),
                             (SELECT TOP 1 purchasedate
                              FROM   tbl_order
                              WHERE  clientid = 1
                              ORDER  BY purchasedate DESC)) /
                                          Count(*) ), Getdate())
FROM   tbl_order
WHERE  clientid = 1 