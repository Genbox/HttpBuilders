# HttpBuilders - A strongly typed API for HTTP headers

[![NuGet](https://img.shields.io/nuget/v/Genbox.HttpBuilders.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Genbox.HttpBuilders/)

### Description
Provides a strongly typed API for building HTTP headers. HTTP has support for many headers, each with their own syntax and rules.

For example, the [HTTP Range header](https://tools.ietf.org/html/rfc7233#section-3.1) says that a server can choose to reject your message if you send duplicate ranges, or if the ranges are not ordered. Adding ranges manually via `bytes=1-40` works fine, until you need to programmically add ranges, you suddenly find yourself writing a lot of code to construct the headers.

This library has done all that for you. You simply create the builder that matches the header you want, add data to it and call `Build()`.

### Features
* Currently supports Accept-Encoding, Content-Disposition, Content-Encoding, Content-Language, Content-Type, ETag, Range and Cache-Control HTTP headers.
* Optimized to output as short headers as possible to save bandwidth.
* Control compatibility and output using options.
* Consistent behavior: All builders give `null` if they are empty.
* `IOptions<T>` support for easy integration with dependency injection.
* High performance and only a few allocations.

### Example
```csharp
RangeBuilder range = new RangeBuilder();
range.Add(1, 20);
range.Add(6, 19);
range.Add(3, 24);

// It automatically sorts and merge overlapping ranges
Console.WriteLine(range.Build()); // bytes=1-24

ContentLanguageBuilder language = new ContentLanguageBuilder();
language.Add("en-US");
language.Add(Language.Danish);

Console.WriteLine(language.Build()); //"en-US, da"
```

See HttpBuilders.Examples for real-world usage.