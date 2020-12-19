var xhr = new XMLHttpRequest();
   xhr.onreadystatechange = function() {
        var parsedResponse = JSON.parse(xhr.responseText);
        document.getElementById('test').innerHTML = parsedResponse[0].author;
   };
   xhr.open('GET', 'https://rocketrestapi.azurewebsites.net/api/Customers');
   xhr.send();