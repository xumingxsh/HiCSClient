# HiCSClient
这是一个C#版的Windows界面程序，主要用来验证实现自己的一些对界面程序的想法。
特点：
1: 将SQL语句从代码中分离出来,存储到配置文件中(如XML),通过一个唯一标识获取具体SQL语句.
2: 提供DataRow,IDictionary等到对象的映射.
3: 提供根据DataRow,IDictionary,对象创建SQL参数
4: 将界面控件的具体显示内容从代码中移动到配置文件,如DataGridView的列信息
5: 将界面控件的数据合法性验证,控件值的获取,控件值的初始化移动到配置文件.
6: 提供一组控件库,简化控件的使用(使用组合而非继承)
注意：
由于用Excel作为数据库，所以需要在机器中注册msjet40.dll。注册的步骤：
1： 打开命令行
2： cd到msjet40.dll所在文件夹
3： 输入regsvr32 msjet40.dll
