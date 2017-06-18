# DataBases

1. Data bases I know are relational and non-realtional data bases. 

2. Relational ones have some kind of relations betweenthe data stored in. Non-realtional are the ones that let you have repeating information stored without having relationshipsbetween the store data

3. Tables in databases are just a structured data held in the the database

4. A primary key is unique and only one as it serves for identifying a concrete object with information in a database
table, while the foreign  key is something that can be the same in more than one column in a given table because it is
used to link our current table content with some objects of information from another table by the primary key of the targeted table

5. 
    * One-to-many
     This is the kind of relationship that if we have tables A and B, table B can have many matching rows in table A, but
     table A can have only one matching row in table B
     * Many-to-many
     In this relationship rows in table A can have many matching rows from table B and vice versa
     * One-to-one
     In this case table A can have only one matching row from table B, and vice versa. Usually the matching row
     is the primary key. This kind of relationship is usually used for inheritance

6. A certain database schema is normalized when all possible repeating information (except for number types)
is put in another table to which then our table refers. Advantages of normalization is that it reduces the size of the database because duplicated information and it alos improves performance

7. Integrity constraints are different constraints for the data we store in our databases that preven us from having a non-valid information stored in the database

8. A Database index is a data structure that helps retrieve information from the database more efficiently. An index is a
copy of selected columns of data. Good thins about them is that they can really improve performance, but this means writing more and xtending our database.

9. Main purpose of SQL language is used for managing data in relational database

10. Transactions are used when modifying the database to make sure that everything has gone right with the modification
and if any unexpected behaviour occurs or the modification is not fully finished all things done during the transaction to the moment of failure are reverted. One example is when transfering mone yfrom one to another account, if person A starts trasferring money to person B nad whe money are being transfered, and suddenly the electicity stops. Without transactions money would be on the way, but neither person A would have them anymore nor person B would have recieved them. With transactions all the processes with the tranferring would be reverted and person A would still have the money he tried to send.

11. NoSQL databases means non-realtional databases

12. Non-relational database is any data base that is not relational.

13. Such database is MongoDB in which there are no relationships between the different dataheld in the database, and duplicated informations is considered to be fine. Such databases is that they are really fast to take information from
but are also slower than the relational databases when it come to modifying content 



