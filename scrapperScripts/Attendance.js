// ==UserScript==
// @name        Librus Scraper - frekwencja
// @namespace    http://tampermonkey.net/
// @version      1.0.0
// @description  try to take over the world!
// @author       You
// @match       https://synergia.librus.pl/przegladaj_nb/uczen
// @icon         https://www.google.com/s2/favicons?domain=librus.pl
// @grant        none
// ==/UserScript==

(function() {
    'use strict';

const student = JSON.parse(sessionStorage.getItem("student"));

    if (!student) {
        console.error("Brak danych ucznia w session storage.");
        return;
    }

        var attendanceData = [];

    const rows = document.querySelectorAll("tr.line0, tr.line1");

      attendanceData = Array.from(rows).map(row => {
          const details = Array.from(row.querySelectorAll("p.box a")).map(link => ({
              AttendanceType: link.getAttribute("title").match(/Rodzaj: (.*?)<br>/)[1],
              Date: link.getAttribute("title").match(/Data: (.*?)<br>/)[1].split(" ")[0],
              Subject: link.getAttribute("title").match(/Lekcja: (.*?)<br>/)[1],
              Teacher: link.getAttribute("title").match(/Nauczyciel: (.*?)<br>/)[1],
              LessonNumber: link.getAttribute("title").match(/Godzina lekcyjna: (.*?)<\/b>/)[1]
          }));

  return details ;
});
    attendanceData = attendanceData.flat()
    if (attendanceData.length === 0) {
        console.warn("Brak danych obecności do przesłania.");
        return;
    }

    const JSONData = {
        FirstName: student.FirstName,
        LastName: student.LastName,
        Class: student.Class,
        Attendances: attendanceData
    }

   console.log(JSONData)
    try {
        const response = fetch("https://localhost:7290/api/Attendances", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(JSONData)
        });

        if (!response.ok) throw new Error("Błąd w odpowiedzi API.");

        console.log("Dane obecności przesłane pomyślnie");
    } catch (error) {
        console.error("Błąd podczas wysyłania danych:", error);
    }
})();