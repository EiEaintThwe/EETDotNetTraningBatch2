
using EETDotNetTraningBatch2.ConsoleApp;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.read();
//adoDotNetExample.create();
//adoDotNetExample.update();
//adoDotNetExample.delete();

//DapperExample dapperExample=new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
//dapperExample.Delete();

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create();
//eFCoreExample.Edit();
//eFCoreExample.Update();
eFCoreExample.Delete();


Console.ReadKey();