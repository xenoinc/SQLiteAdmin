# Project Framework
This project definitively uses C# and our goal is to have a cross-platform desktop project. First and foremost, it will support Microsoft Windows.

## Framework Pros and Cons
Below is a quick list of pros and cons to help others understand the path which we are taking.

We're still weighing out the options of which framework to use. So far, WinForms is on the chopping block.

### WinForms
*This project has WinForms marked for deprecation*

| Pros | Cons |
|:-----|:-----|
| Fast to stand-up | AvalonEdit must be in a wrapper |
|  | MVP/MVC isn't right out of the box |
|  | Doesn't render well on multi-platforms |
|  |  |

### WPF with Prism

| Pros | Cons |
|:-----|:-----|
| Its flavor of XAML is common | Multi-platform is coming in .NET Core 3.0 (_still in preview_) |
| Prism with DryIOC |  |
| MVVM support |  |
| AvalonEdit is written in WPF |  |
|  |  |

### Avalonia with ReactiveUI

| Pros | Cons |
|:-----|:-----|
| Multi-platform out-of-the box | Not traditional XAML - _young project_ |
| MVVM support | Prism not supported |
| AvaloniaEdit is ported for Avalonia | Reactive IoC is a learning curve for our developers |
|  |  |

## Syntax Highlighting
Our current editor is [AvalonEdit](https://github.com/icsharpcode/AvalonEdit).

Other editors considered:

| Editor | Framework | Notes |
|:-------|-----------|:------|
| [ScintillaNET](https://github.com/jacobslusser/ScintillaNET) | WinForms |  |
| [RoslynPad](https://roslynpad.net/) [GitHub](https://github.com/aelij/RoslynPad) | WPF | _Port of AvalonEdit_ |
| [AvaloniaEdit](https://github.com/AvaloniaUI/AvaloniaEdit) | Avalonia | _Port of AvalonEdit_ |
