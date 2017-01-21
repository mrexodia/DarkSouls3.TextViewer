# Dark Souls 3 Text Viewer

This tool helps you view all in-game text of [Dark Souls 3](https://www.darksouls3.com).

**Disclaimer**: The contents of the `ds3.json` file are derived from the Dark Souls 3 game files owned by [From Software](http://www.fromsoftware.jp). They are extracted for research purposes and there will be no commercial usage.

## Filters

You can use filters to find relevant information. Text is compared case-insensitive and you can combine multiple filters with operators & (AND) | (OR) ~ (NOT).

- Identifiers can be found with '{id}'
- DLC version can be found with 'dlcN'
- Item type can be found with '{type}'

Operators are evaluated in the following order:

1. Parentheses
2. NOT
3. AND
4. OR

```
a|(b&c|~d) = a|((b&c)|(~d))
```

### Examples

- Filter: `aldrich|deep`
- Effect: Everything containing 'aldrich' or 'deep'


- Filter: `god&swamp`
- Effect: Everything containing 'god' and 'swamp'


- Filter: `aldrich&deep|children`
- Effect: With braces: aldrich&(deep|children)


- Filter: `{1200}`
- Effect: Matches text with ID 1200


- Filter: `magic&~{Magic}`
- Effect: All non-{Magic} items containing 'magic'