// ==UserScript==
// @name         Librus Scraper - Uczeń i Oceny
// @namespace    http://tampermonkey.net/
// @version      1.0
// @description  Skrypt do scrapowania danych ucznia i ocen z Librusa
// @author       Ty
// @match        https://synergia.librus.pl/przegladaj_oceny/uczen
// @icon         https://www.google.com/s2/favicons?domain=librus.pl
// @grant        none
// ==/UserScript==

(function() {
    'use strict';

    // Funkcja do wysyłania danych do API
    function sendData(data) {
        fetch('https://localhost:7290/api/Students/withGrades', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(response => response.json())
        .then(data => console.log('Success:', data))
        .catch((error) => console.error('Error:', error));
    }

    // Zbieranie danych o uczniu
    const studentData = document.querySelector('.container-icon p').innerText;
    const [fullName, classInfo] = studentData.match(/Uczeń: (.*?)\nKlasa: (.*)/).slice(1, 3);
    const [firstName, lastName] = fullName.split(' ');

    // Zbieranie ocen
    let grades = [];

    // Pobieranie wszystkich wierszy z ocenami
    document.querySelectorAll('tr').forEach((row) => {
        // Sprawdzanie, czy wiersz jest ukryty lub nie zawiera ocen
        if (row.style.display === 'none' || row.querySelectorAll('.grade-box').length === 0) {
            return; // Pomijamy wiersze bez ocen
        }

        // Pobieranie przedmiotu
        let subject = row.querySelector('td:nth-child(2)') ? row.querySelector('td:nth-child(2)').innerText.trim() : null;

        // Pobieranie wszystkich ocen dla danego przedmiotu
        row.querySelectorAll('.grade-box').forEach((gradeBox) => {
            let gradeValue = gradeBox.innerText.trim(); // Wartość oceny
            let detailsLink = gradeBox.querySelector('a').getAttribute('title');

            // Rozdzielenie szczegółów oceny na podstawie znacznika <br>
            let details = detailsLink.split('<br>');

            // Bezpieczne pobieranie szczegółów z walidacją, czy element istnieje
            let category = details[0] ? details[0].replace('Kategoria: ', '').trim() : "";
            let date = (details[1] ? details[1].replace('Data: ', '').trim() : "").split(" ")[0];
            let teacher = details[2] ? details[2].replace('Nauczyciel: ', '').trim() : "";
            let count = details.includes('Licz do średniej: tak') || false;
            let weight = details[4] ? details[4].replace('Waga: ', '').trim() : "";
            let comment = details[6] ? details[6].replace('Komentarz: ', '').trim() : "";

            if (subject && gradeValue) {
                grades.push({
                    Subject: subject,
                    GradeValue: gradeValue,
                    Category: category,
                    Date: date,
                    Teacher: teacher,
                    Weigth: weight,
                    Comment: comment,
                    CountToAvg: count
                });
            }
        });
    });

    // Tworzenie obiektu JSON z danymi ucznia i ocenami
    const studentJson = {
        FirstName: lastName,
        LastName: firstName,
        Class: classInfo,
        Grades: grades
    };

    console.log(studentJson)

    // Wysyłanie danych do API
    sendData(studentJson);
})();
