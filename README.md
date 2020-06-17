# Rotate Screen for Win 10

The program is written in WPF(C#) on `.net Framework 4.6`, in which the Windows API is called to rotate screen like the action in the Screen Setting. The UI is written in **Chinese** but with **English comments**.

---

程序是用WPF（C#）写的，基于`.net Framework 4.6`，通过调用Windows API的方式进行屏幕旋转。和设置里面的功能相同，就是用起来方便点。

## What can it do

- Select the screen(s) you want, then rotate.（选择想要被旋转的屏幕，然后按需求旋转）
- Recover the screen(s) you want.（把之前旋转的恢复正常）

## How to run

First, make sure you're running on Win10. Then, just clone or download the repo, open the `sln` file, switch to `Release` and press `Ctrl+F5`, you can see the program.

---
首先要求Win10系统，之后，clone或者下载这个repo，打开`sln`文件，选择`Release`之后按`Ctrl+F5`，就可以生成并运行程序了。

## Why not .Net Core

Since it can't run on *NIX and depends largely on Windows API, `dotnet core` is not really useful. What's more, `.net Framework 4.6` exists on every Win10 so it's easy to use.

---
由于本程序使用了Windows API，程序并不能在*NIX系列系统运行，所以`dotnet core`的跨平台能力也就没什么用了。而且，Win10上自带`.net Framework 4.6`，何乐而不为。
