# Modul 151 - Ludothek 
## Description
This project is part of the final for M151 at GBS SG.
The goal is to implement a web-based "Ludothek". The database used in this project has been implemented in M152.

## Installation
- Clone solution
- Connect to db: "(localdb)\MSSQLLocalDb"
- Create database using the script "Init_Databse.sql"
- Fill the database with dummy data (run script: "Seed.sql")
- Open Solution
- Run `Update-Database` in the PM-Console
- Start Webapp

## ToDo
- Documentation
- Prolonging Rentals --> Done

## German / English Mapping

| Db            |Software       |
| ------------- |-------------|
| Filiale       | Branch        |
| Verband       | Federation    |
| Spiel         | Game          |
| Ausleihe      | Rental         |
| Tarifkategorie | PriceCategory |
