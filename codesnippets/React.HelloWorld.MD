### Helloworld.js

```javascript
<div id="root"></div>
<script crossorigin src="https://unpkg.com/react@16/umd/react.development.js"></script>
<script crossorigin src="https://unpkg.com/react-dom@16/umd/react-dom.development.js"></script>
<script crossorigin src="https://unpkg.com/babel-standalone@6/babel.min.js"></script>

<script type="text/babel">
    const rootElement = document.getElementById("root")
    const Message = props=> <div>{props.children} </div>
    const element = (
        <div class Name="container">
            <Message>Hello World</Message>
            <Message>Hi world</Message>
        </div>
    )
    
    ReactDOM.render(element,rootElement)
</script>
```