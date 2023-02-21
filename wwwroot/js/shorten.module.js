const frm = document.querySelector(".shortenform");

frm.addEventListener("submit", function (e) {
    e.preventDefault();
    e.stopPropagation();

    frm.classList.add('was-validated');

    const tb = document.querySelector('#FullUrl');

    if (frm.checkValidity()) { // the form is valid

        fetch("/api", {
            method: "POST",
            headers: {
                "Content-Type": "application/json;"
            },
            body: JSON.stringify(tb.value)
        })
            .then(response => response.json())
            .then(data => {
                    var kvps = data;
                document.querySelector('#shortUrl').value = kvps["shortUrl"];
                document.querySelector('#countUrl').value = kvps["count"];
                document.querySelector('#countClick').value = kvps["clickCount"];
            });
    }
});





















//document.querySelector('#btnSubmit').addEventListener('click', async e => {
//    const payload = {};
//    var furl = document.querySelector('#FullUrl').value;
//    validateURL(furl)
//        if (/^(http(s):\/\/.)[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$/g.test(url)) 
//    payload["fullUrl"] = document.querySelector('#FullUrl').value;
//    const req = {
//        method: 'POST', // *get, post, put, delete, etc.
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(furl)

//    };
//    try {
//        const res = await fetch('/api', req);
//        if (res.status === 400) {
//            const err = await res.json();
//            return;
//        }
//        if (res.status === 201) {
//            var kvps = await res.json();
//            document.querySelector('#shortUrl').value = kvps["shortUrl"];
//            document.querySelector('#countUrl').value = kvps["count"];
//        }
//    } catch (error) {
//        debugger;
//    }
//});



//document.querySelector('#btnSubmit').addEventListener('click', async e => {
//    const payload = document.querySelector('#FullUrl');
//    const item = {
//        fullUrl: payload.value
//        Count: payload.value
//    }
//    //var furl = document.querySelector('#FullUrl').value;
//    //var count = document.querySelector('#counturl').value;
//    payload["fullUrl"] = document.querySelector('#FullUrl').value;
//    const req = {
//        method: 'POST', // *get, post, put, delete, etc.
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(item)

//    };
//    try {
//        const res = await fetch('/api', req);
//        if (res.status === 400) {
//            const err = await res.json();
//            return;
//        }
//        if (res.status === 201) {
//            var kvps = await res.json();
//            document.querySelector('#shortUrl').value = kvps["shortUrl"];
//            document.querySelector('#fullUrl').value = kvps["counturl"]
//        }
//    } catch (error) {
//        debugger;
//    }
//});


//function validateURL(url) {
//    if (/^(http(s):\/\/.)[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$/g.test(url)) {
//        console.log('Valid');
//    } else {
//        console.log('Not Valid');
//    }
//}