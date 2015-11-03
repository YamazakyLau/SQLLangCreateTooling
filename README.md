__帮助说明__

#####a.	
程序适用于向已有数据库表中<font color=blue>增删改</font>一定的数据，通常情形下数据内容已经确定，然而并没有合适的方法快速添加到数据库；
***

#####b.	
您可以先将数据有序的加入到EXCEL表中，软件帮您生成<font color=red>Structured Query Language</font>
[Structured Query Language介绍](http://baike.baidu.com/link?url=Cpq9E0ee28w2onlnqJh_f3qJdviVvBM3vyizpoW9OYRImp_n2ZC4oRM9PywjRLtLA7qpFgBU4co70ceuHExDyziKMYubvyKZbimr_p0DykmvYgUM4fXVxmF45SfcyiSKHXMNhpGubp83CrlMFr4f7nKQLix-OSAQByqo8LlAW_7"百度地址")
***

#####c.	
支持2003/2007+版EXCEL文件，后缀名*.xls/*.xlsx!。
***

#####d.	
支持选择第几张表格的内容，表格中不要有间隙单元格或不整齐非空单元格（如果确实有未填表，仍然建议采用数据库默认字段填充，以免生成语句语法不合要求）。
***

#####e.	
手动输入数字1~9，分别表示第一张表至第9张表，实际证明Excel文件中Sheet表的排序与所见的顺序可能不一样，但软件有会将表的名称显示出来供您比对！
***

#####f.	
文件名、表名尽量使用英文+数字；因为有可能编码无法被程序识别。（<font color=green>本程序在Microsoft Visual Studio 2008版IDE上调试通过，实际测试系统为简体中文版64位Win7电脑</font>）
***

#####g.	
本程序开源代码首发地址：[Github查看代码](https://github.com/YamazakyLau/SQLLangCreateTooling.git"Github")
***

#####h.	
程序引用开源组件<font color=red>NPOI、ExcelPackage</font> ，理论上不需要您的电脑上安装EXCEL阅读软件也能使用，软件抛弃原来的OleDbConnection（或叫OLEDB）程序接口，但仍保留代码痕迹。
