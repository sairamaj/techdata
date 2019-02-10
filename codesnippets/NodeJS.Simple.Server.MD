## Simple web server using NodeJS

### Package.json
```json
{
    "dependencies": {
        "express": "4.16.4"
    }
}
```

```javascript
const express = require('express')
const app = express()
const port = 3000

app.get('/', (req, res) => res.send('Hello World!'))

app.listen(port, () => console.log(`Example app listening on port ${port}!`))
```

* npm install
* node index.js
