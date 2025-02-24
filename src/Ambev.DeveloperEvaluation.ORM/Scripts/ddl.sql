
create table "Users" (
    "Id" uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    "Username" VARCHAR(50) NOT NULL,
    "Password" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL,
    "Phone" VARCHAR(20) NOT NULL,
    "Status" VARCHAR(20) NULL,
    "Role" VARCHAR(20) NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT now(),
    "UpdatedAt" TIMESTAMP NULL
);

create table "Product" (
    "Id" uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    "Description" VARCHAR(100) NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT now(),
    "UpdatedAt" TIMESTAMP NULL
);


create table "Sales" (
    "Id" uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    "Number" SERIAL NOT NULL,
    "Customer" VARCHAR(100) NOT NULL,
    "Branch" VARCHAR(100) NOT NULL,
    "Total" DECIMAL(12,2) NOT NULL,
    "IsCanceled" BOOLEAN NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT now(),
    "UpdatedAt" TIMESTAMP NULL
);


create table "SalesItems" (
    "Id" uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    "SalesId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Price" DECIMAL(10,2) NOT NULL,
    "Quantity" INT NOT NULL,
    "Discount" DECIMAL(10,2) NOT NULL,
    "Total" DECIMAL(12,2) NOT NULL,
    "IsCanceled" BOOLEAN NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT now(),
    "UpdatedAt" TIMESTAMP NULL,
    CONSTRAINT "FK_Sales_SalesId" FOREIGN KEY ("SalesId") REFERENCES "Sales"("Id"),
    CONSTRAINT "FK_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Product"("Id")
);