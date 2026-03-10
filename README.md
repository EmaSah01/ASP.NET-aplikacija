# ASP.NET Ratings API

## Opis projekta
Ova ASP.NET aplikacija pruža REST API za upravljanje ratingom proizvoda.  
Aplikacija uključuje:

- CRUD operacije za ratinge (Create, Read, Update, Delete)  
- M2M (Machine-to-Machine) endpoint za prijem ratinga od uređaja  
- Logovanje aktivnosti u konzolu i fajl  
- Integracija sa bazom podataka preko Entity Framework Core  

Projekt je zamišljen kao primjer modernog ASP.NET backend-a sa čistom arhitekturom:  
`Controller → Service → DAO → Database`.

---

## Tehnologije

- .NET 7 / ASP.NET Core  
- Entity Framework Core  
- SQL Server (može i LocalDB)  
- Serilog za logovanje u fajl  
- Swagger za dokumentaciju API-ja  

---

## Instalacija i pokretanje

1. Klonirajte repo:

```bash
git clone <repo-url>
cd ASP.NET_aplikacija
