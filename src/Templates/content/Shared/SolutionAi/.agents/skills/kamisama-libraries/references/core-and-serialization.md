# Core And Serialization Snapshot

- `KamiSama.Extensions`: array padding/trimming, byte/string conversion, crypto, hashes, Persian dates, exact stream reads, time spans, and safe conversion.
- `KamiSama.Extensions.Paging.SearchModel`: use `All` or `FromPage(pageNo, pageSize)`.
- `KamiSama.Extensions.Paging.PagedResult<T>`: standard multi-item result; use `ConvertTo` or `ConvertToAsync` for mappings.
- `KamiSama.Extensions.IQueryableExtensions.MakePaged`: creates a `PagedResult<T>` from an `IQueryable<T>`.
- `KamiSama.Extensions.Json`: JSON extension methods and BigInteger, dynamic, hex-byte, hierarchical, and TimeSpan converters.
- XML helpers: `AutoXmlElement<T>`, `AutoXmlElementAttribute`, `AutoXmlArrayItemAttribute`, `XmlAttributeOverridesExtensions`, and `XmlSerializationExtensions`.

Use exact namespaces and inspect the installed API before relying on overload details.
