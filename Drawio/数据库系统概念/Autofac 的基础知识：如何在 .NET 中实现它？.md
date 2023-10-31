# Autofac 的基础知识：如何在 .NET 中实现它？

![](E:\autofac\autofac.png)

如果你过去使用过依赖注入，则一定知道它为什么有用。依赖注入提供了松散耦合，并有助于维护和测试应用程序。

依赖注入和 IoC 概念构成了大多数面向对象应用程序的核心。

IoC 是一个通用术语，它暗示控制流为：框架调用应用程序提供的实现，而不是调用框架中的方法。

依赖注入由 .NET 中的 DI 容器提供。它是预构建的，不需要额外的安装。

AutoFac 是一个功能强大的第三方 DI 容器，在 .NET 开发人员中广泛使用。让我们更深入地了解什么是Autofac以及为什么它很有用。

**目录**

- 一些背景知识
- 什么是Autofac？
- 与内置 DI 容器相比，Autofac 的优势
- Autofac的实际实现
- 结论

## **背景**

依赖注入是 IoC（控制反转）的一种形式，其中实现通过构造函数或 setter 传递，应用程序使用这些构造函数或 setter 才能正常运行。

换句话说，它是一种编程技术，允许类独立于其依赖项。这使开发人员能够对多个类进行大量控制。依赖注入由预构建的 DI 容器或第三方 DI 容器提供。但是，在开发企业级应用程序时，开发人员总是寻求第三方DI容器（如AutoFac）的帮助。

## **什么是AutoFac？**

AutoFac 是一个控制反转容器，用于解析应用程序的依赖项。这意味着它也是一个依赖注入框架。

如果你不熟悉面向对象世界中的这个说法，它是一种注入依赖关系的方法，这些依赖项通常由构造函数中的其他类所依赖。Autofac被誉为.NET社区中使用最好用的框架。它是开发人员中下载量最大的Nuget包之一。AutoFac为 ASP.NET MVC框架提供了更好的集成。

AutoFac 管理类的依赖关系，以便应用程序在大小和复杂性纵向扩展时可以轻松更改。让我们来看看为什么内置的 DI 容器会被 AutoFac 取代。

## **与内置 DI 容器相比，AUTOFAC 的优势**

1. .NET DI 容器无助于验证配置，因此很难发现由常见配置错误引起的问题。在大型应用程序中，很难自己发现配置错误。
2. .NET DI 容器仅提供一个构造函数注入。
3. 使用 AutoFac，可以使用内置 IoC 容器所没有的功能，例如属性注入。
4. 内置容器非常轻，是基本应用程序的默认容器。用户可以轻松切换到第三方 IoC 容器，如 AutoFac 或 structuremap。
5. AutoFac 支持各种应用程序设计，只需要很少的代码量就能使用，学习成本很低。
6. 实现第三方 IoC 容器（如 AutoFac）可以生成可重用的、更具可读性的和易于测试的代码，从而集中依赖关系管理的逻辑。
7. Autofac 涵盖了 IoC 容器提供的所有功能，以及其他有助于应用程序配置、管理组件生命周期以及管理监视下的多个依赖项的微妙功能。

## **AUTOFAC 的实际实现**

要解锁依赖注入的全部好处，最好使用第三方DI容器，而不是内置DI容器。现在，让我们使用 AutoFac 执行简单的依赖注入。

### 步骤1

打开 Visual Studio 并创建一个新项目。从指定的运行时环境列表中选择控制台应用 （.NET Core）。

![img](https://www.partech.nl/publication-image/%7B7B1D1F99-576B-4495-AD99-C6595D3BC612%7D)

### 步骤2

下一步是配置项目。指定项目的名称以及要保存项目的位置。继续创建。

### 步骤3

Visual Studio 现在会自动创建默认的 Hello world 程序，即控制台应用程序。

在开始任务之前，需要添加第三方 DI 容器扩展。转到项目右上角的"解决方案资源管理器"选项卡。右键单击依赖项，然后选择"管理 NuGet 包"。现在，通过搜索包栏进行搜索来安装 AutoFac 包。

![img](https://www.partech.nl/publication-image/%7BBF2820F8-1A7E-4527-AB00-0CDD4095825E%7D)

### 步骤4

现在已安装 AutoFac，让我们使用 AutoFac 实现依赖注入。下面是一个简单的控制台应用程序，涉及使用 AutoFac 实现依赖注入。

```
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using Autofac;



public interface IMobileServive

{

  void Execute();

}

public class SMSService : IMobileServive

{

  public void Execute()

  {

 Console.WriteLine("Partech SMS service executing.");

  }

}



public interface IMailService

{

  void Execute();

}



public class EmailService : IMailService

{

  public void Execute()

  {

    Console.WriteLine("Partech Email service Executing.");

  }

}



public class NotificationSender

{

  public IMobileServive _mobileSerivce = null;

  public IMailService _mailService = null;



  //injection through constructor  

  public NotificationSender(IMobileServive tmpService)

  {

    _mobileSerivce = tmpService;

  }

  //Injection through property  

  public IMailService SetMailService

  {

    set { _mailService = value; }

  }

  public void SendNotification()

  {

    _mobileSerivce.Execute();

    _mailService.Execute();

  }

}



namespace Client

{

  class Program

  {

    static void Main(string[] args)

    {

      var builder = new ContainerBuilder();

      builder.RegisterType<SMSService>().As<IMobileServive>();

      builder.RegisterType<EmailService>().As<IMailService>();

      var container = builder.Build();



      container.Resolve<IMobileServive>().Execute();

      container.Resolve<IMailService>().Execute();

      Console.ReadLine();

    }

  }

}
Copy 
```

在这里，我们实现了两个接口类及其相应的具体类。

然后，我们实现了一个依赖于 mailService 和 mobileService 的通知发送方类。我们通过构造函数注入了两个类的依赖关系。查看 Main（） 函数以查看依赖项类型的存储库并构建存储库。

这是代码的输出 -

![img](https://www.partech.nl/publication-image/%7B0E1BE86D-5CA6-490B-9D45-9BD10C801F4C%7D)

## **结论**

要使类独立于其依赖项，明智的做法是使用依赖注入。它使你能够替换或更改依赖项，而不会中断类组件或主代码。因此，对于小规模应用，可以使用内置的DI容器。但是，当涉及到大规模远程应用程序时，Autofac是首选，因为它提供了.NET内置DI容器所缺乏的大量功能。

<iframe id="dsq-app1736" name="dsq-app1736" allowtransparency="true" frameborder="0" scrolling="no" tabindex="0" title="Disqus" width="100%" src="https://disqus.com/embed/comments/?base=default&amp;f=partech&amp;t_i=%7B78A4E511-05EB-43D3-91BF-73CA2BBDC62A%7D&amp;t_u=https%3A%2F%2Fwww.partech.nl%2Fnl%2Fpublicaties%2F2021%2F05%2Fbasics-of-autofac-how-to-implement-it-in-asp-net-application&amp;t_d=Basics%20of%20AutoFac%20How%20to%20implement%20it%20in%20Dot%20NET%20application%20-%20ParTech&amp;t_t=Basics%20of%20AutoFac%20How%20to%20implement%20it%20in%20Dot%20NET%20application%20-%20ParTech&amp;s_o=default#version=4474eb952b0ac3bafd98c3224c1d140c" horizontalscrolling="no" verticalscrolling="no" style="box-sizing: border-box; width: 1px !important; min-width: 100%; border: none !important; overflow: hidden !important; height: 418px !important;"></iframe>

## 相关



## 最近的

- [.NET 中的热重载](https://www.partech.nl/nl/publicaties/2022/01/hot-reload-in-net)昨天上午 10：00
- [什么是 AWS 质子？](https://www.partech.nl/nl/publicaties/2022/01/what-is-aws-proton)星期三上午 10：00
- [TCP 与 UDP：你需要了解的一切](https://www.partech.nl/nl/publicaties/2022/01/tcp-vs-udp---everything-you-need-to-know)星期一上午 10：00
- [什么是开放电信？](https://www.partech.nl/nl/publicaties/2022/01/what-is-opentelemetry)07 一月 2022 在 10：00
- [F# 6 中有哪些新增功能？](https://www.partech.nl/nl/publicaties/2022/01/whats-new-in-f-sharp-6)05 1 月 2022 在 10：00

- [顾问](https://www.partech.nl/nl/diensten/consultancy)
- [管理](https://www.partech.nl/nl/diensten/beheer)
- [训练](https://www.partech.nl/nl/diensten/training)
- [通讯](https://www.partech.nl/nl/nieuwsbrief)

- [在帕尔科工作](https://www.partech.nl/nl/over-partech/werken-bij-partech)
- [出版物（博客）](https://www.partech.nl/nl/publicaties)
- [投资 组合](https://www.partech.nl/nl/over-partech/portfolio)
- [联系](https://www.partech.nl/nl/contact)

#### 超越帕尔泰克

ParTech是你在线平台的技术合作伙伴。我们专注于微软堆栈的开发，咨询，支持和管理以及培训。

[关于帕尔泰克](https://www.partech.nl/nl/over-partech/wie-wij-zijn)

#### 联系我们

Rompertdreef 9
5233 ED 's-Hertogenbosch


 +31 (0)85 - 0020 678
 [info@partech.nl](mailto:info@partech.nl)

版权所有 © ParTech， 2020