# Harjutus 1 – Tallinna ilmaennustus kasutades Yr.no API't

## Projekti kirjeldus

Selle programmi eesmärk on kuvada Tallinna ilmaennustus kasutades Yr.no (MET Norway) API-t.

Programm saadab HTTP GET päringu Yr.no API aadressile, kasutades Tallinna koordinaate (laiuskraad 59.4370 ja pikkuskraad 24.7536). Vastus saadakse JSON-formaadis.

JSON vastusest loetakse välja ilmaennustuse andmed, mis asuvad `timeseries` massiivis. Iga kirje sisaldab prognoosi kindlaks ajaks ning õhutemperatuuri.

Programm kasutab `for`-tsüklit, et kuvada järgmise 10 tunni ilmaennustus. Iga rea kohta väljastatakse:

* prognoosi aeg;
* õhutemperatuur Celsiuse kraadides.

## Kasutatud tehnoloogiad

* C#
* .NET Console Application
* HttpClient HTTP päringute tegemiseks
* System.Text.Json JSON andmete töötlemiseks

## Programmi tööpõhimõte

1. Luua HTTP klient.
2. Lisada päringule `User-Agent` päis.
3. Saata päring Yr.no API-le.
4. Lugeda JSON vastus.
5. Leida `properties -> timeseries` andmed.
6. Tsükli abil kuvada järgmise 10 tunni temperatuurid.

## Näidisväljund

2025-09-17T09:00:00Z 19C

2025-09-17T10:00:00Z 20C

2025-09-17T11:00:00Z 19C

...
