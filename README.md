Program demonstrating a bug when rendering partial templates.
When rendering an indented partial template, additional whitespace gets appended to the end of {{tokens}}
that appear in the partial template

Base template:
```mustache
<div>
    {{>Body}}
</div>
```

Body Template:
```mustache
<a href="{{Url}}" target="_blank">
    My Link
</a>
```

Data:
```json
{
    "Url": "https://github.com"
}
```

Expected output:
```html
<div>
    <a href="https://github.com" target="_blank">
        My Link
    </a>
</div>
```

Actual output:
```html
<div>
    <a href="https://github.com    " target="_blank">
        My Link
    </a>
</div>
```