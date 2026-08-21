# Verify

Run `dotnet build` on the narrowest affected `.slnx` or project. Then inspect generated configuration for empty connection-string placeholders, verify controllers require authorization, and confirm no extra template manifests or nested `content/content` paths are packaged.
