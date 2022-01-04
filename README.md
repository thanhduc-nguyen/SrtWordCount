# SrtWordCount
Count words in Srt files.

### Project anatomy
- SrtWordCount.ConsoleApp: console application to test Srt Word Count library
- SrtWordCount.Core: Srt Word Count library
- SrtWordCount.Data: project for Data access
- SrtWordCount.WebApp: Web application for CRUD, and consume Srt Word Count library

There are 30 SRT sample files in SrtWordCount.ConsoleApp. SRT filename format should be [Genre] Movie name Year.srt but not mandatory.
Naming like this helps the Srt Word Count library to acquire some extra data.

### Setup
Run build.cmd to generate DB schema and build SrtWordCount.WebApp project.
