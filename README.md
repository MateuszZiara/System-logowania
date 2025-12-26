Założenia projektowe:
Przygotowanie bezpiecznego systemu logowania do aplikacji spełniającego poniższe wymagania:

Przechowywanie danych logowania w bazie danych,
Zastosowanie funkcji skrótu Argon2 lub scrypt do przechowywania haseł (zgodnej z zaleceniami OWASP dotyczącymi wydajności i bezpieczeństwa) ,
Dodawanie soli do hasła przed generowaniem funkcji skrótu,
Zastosowanie podstawowej polityki haseł (długość, złożoność) zgodnej z OWASP ASVS 4.0.
Dodanie wskaźnika siły hasła bazującego na entropii hasła,
Dodanie do systemu logowania obsługi uwierzytelnienia dwuskładnikowego (TOTP),
Zabezpieczenie przed stosowanie popularnych haseł (lokalna baza/ API),
Blokada konta na określony czas po kilku nieudanych próbach logowania.
