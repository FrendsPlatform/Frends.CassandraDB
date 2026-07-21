# Changelog
 
## [1.1.0] - 2026-07-21
### Changed
- The task now targets .NET 8.
- Added an **Options** parameter to the task. You can now control error handling behaviour: set *Throw error on failure* to `false` to receive errors as a result object instead of an exception, and optionally provide a custom error message via *Error message on failure*.
- The **QueryResults** property in the result now returns a list of rows (each row as a dictionary of column name to value) instead of a JSON token. This makes the result easier to use without needing a JSON library.
- Added an **Error** property to the result, populated when the task fails and *Throw error on failure* is disabled.

## [1.0.0] - 2023-10-30
### Added
- Initial implementation