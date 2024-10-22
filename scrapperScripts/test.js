// ==UserScript==
// @name         Librus - Zbieranie danych ucznia i wysyłanie do API
// @namespace    http://tampermonkey.net/
// @version      1.1
// @description  Zbieranie imienia, nazwiska i klasy ucznia na Librusie oraz wysyłanie do API
// @author       TwojeImie
// @match        https://synergia.librus.pl/przegladaj_oceny/uczen
// @grant        none
// ==/UserScript==

(function() {
    'use strict';

  
    const infoElement = document.querySelector('.container-icon td p');

    if (infoElement) {
    
        const infoText = infoElement.innerText;

        const nameMatch = infoText.match(/Uczeń:\s(.+)\n/);
        const classMatch = infoText.match(/Klasa:\s(.+)\s/);

        if (nameMatch && classMatch) {
            const fullName = nameMatch[1];   
            const className = classMatch[1]; 

            
            const [firstName, lastName] = fullName.split(' ');

            
            const studentData = {
                firstname: firstName,
                lastname: lastName,
                class: className
            };

            
            console.log('Dane ucznia (JSON):', studentData);

            
            fetch('https://localhost:7290/api/Students', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(studentData)
            })
            .then(response => {
                if (response.ok) {
                    console.log('Dane zostały pomyślnie wysłane do API.');
                } else {
                    console.error('Wystąpił błąd podczas wysyłania danych do API.');
                }
            })
            .catch(error => {
                console.error('Błąd:', error);
            });

        } else {
            console.error('Nie można znaleźć danych ucznia.');
        }
    } else {
        console.error('Element z informacjami o uczniu nie został znaleziony.');
    }
})();