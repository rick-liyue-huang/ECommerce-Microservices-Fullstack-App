


here will add the comments for the whole project and no push to remote

here I will run the postgres on dorcker, and 

docker run --name user-postgres-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=password \
  -e POSTGRES_DB=ecommerce_user_db \
  -p 3005:5432 \
  -d postgres

and use the following command: jdbc:postgresql://localhost:3005/ecommerce_user_db to connect to the database from dbeaver. and the username and password is rickhuang and password.

here we need to note the following matching strings for the database:

docker run --name eCommerceUsers -e POSTGRES_PASSWORD=password -p 5436:5432 -d postgres
jdbc:postgresql://localhost:5436/eCommerceUsers
Host=localhost;Port=5436;Database=eCommerceUsers;Username=postgres;Password=password
but the key point is the keep all the comlumns name and table name is lower case on the code.