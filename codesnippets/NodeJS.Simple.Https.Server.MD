## Simple web server using NodeJS

```bat
"C:\Program Files\Git\usr\bin\"openssl req -days 1095 -x509 -out localhost.crt -keyout localhost.key -newkey rsa:2048 -nodes -sha256 -subj "/CN=localhost" -extensions EXT -config ./localhost.config
```

```ini
[dn]
CN=localhost

[req]
distinguished_name = dn

[EXT]
subjectAltName=DNS:localhost
keyUsage=digitalSignature
extendedKeyUsage=serverAuth
```

### Package.json
```json
{
    "dependencies": {
        "express": "4.16.4",
        "https": "1.0.0"
    }
}

```

```javascript
const express = require("express");
const https = require('https')
const fs = require('fs')
const app = express();
const port = 443;

app.get("/", (req, res) => {
  console.log("in get...");
  res.send("Hello World!");
});

app.get("/signin-oidc", (req, res) => {
    console.log("in get  signin-oidc");
    res.send("got in to signon-oidc");
  });


  https.createServer({
    key: fs.readFileSync('localhost.key'),
    cert: fs.readFileSync('localhost.crt')
  }, app)
  .listen(port, function () {
    console.log(`Listening ${port}`)
  })

```

* npm install
* node index.js

[source](https://timonweb.com/posts/running-expressjs-server-over-https/)
