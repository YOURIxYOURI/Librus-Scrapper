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
              type: link.getAttribute("title").match(/Rodzaj: (.*?)<br>/)[1],
              date: link.getAttribute("title").match(/Data: (.*?)<br>/)[1].split(" ")[0],
              lesson: link.getAttribute("title").match(/Lekcja: (.*?)<br>/)[1],
              topic: link.getAttribute("title").match(/Temat zajęć: (.*?)<br>/)[1],
              teacher: link.getAttribute("title").match(/Nauczyciel: (.*?)<br>/)[1],
              hour: link.getAttribute("title").match(/Godzina lekcyjna: (.*?)<\/b>/)[1],
              student: student
          }));

  return details ;
});
    attendanceData = attendanceData.flat()
    if (attendanceData.length === 0) {
        console.warn("Brak danych obecności do przesłania.");
        return;
    }

   console.log(attendanceData)
    try {
        const response = fetch("https://localhost:7290/api/Attendances", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(attendanceData)
        });

        if (!response.ok) throw new Error("Błąd w odpowiedzi API.");

        console.log("Dane obecności przesłane pomyślnie");
    } catch (error) {
        console.error("Błąd podczas wysyłania danych:", error);
    }
})();