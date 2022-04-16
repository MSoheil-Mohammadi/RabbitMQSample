﻿using RPC.Rpc;

var rpcClient = new RpcClient();

Console.WriteLine(" [x] Requesting fib(30)");
var response = rpcClient.Call("30");

Console.WriteLine(" [.] Got '{0}'", response);
rpcClient.Close();