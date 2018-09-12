# DotNet46
## 集合
---
### 1.List\<T\>
 __List是基于容量可变泛型列表.__

#### 主要内容
在List\<T\> 内部首先定义了一个泛型数组_items,所有对List的操作都会映射到这个数组上;

_defaultCapacity = 4; 这个是List默认的容量大小，这个字段作用于List中添加第一个元素时

List中有三个构造函数:
- List() 使用_emptyArray = new T[0];进行初始化items
- List(int capcity) 使用给定的 capcity 来初始化_items
- List(IEnumrable<T> collection) 使用实现了IEnumrable接口的集合来初始化List
特殊的是第三个构造器,调用c.CopyTo(_items,0)，collection中的元素全部复制到List中

__public int Capcity{get{...} set{...}}__
value的值必须大于_size的值，然后新建一个容量为value的数组,再调用Array.Copy方法将将list中的_items 转移到 新建的数组中,最后再将数组赋值给_items
__List中Capcity增加的规则__:如果不采用给定Capcity的话，则使用_emptyArray初始化_item,即初始化容量为0,在增加第一个元素之前，Capcity会增长为4，之后，每当准备突破容量临界时，容量进行2倍扩增

__public int Count{get{...}}__
获取的是List中实际数据的大小

__public T this[int index]{get{...} set{...}}__ 
 索引器

__public void Add(T item)__ 
先EnsureCapcity,在添加

__public void AddRange(IEnumrable<T\> collection)__ 
基本上也是也保证容量，再调用Array.Copy来进行增加

__public void BinarySearch(T item)__ 
调用Array.BinarySearch 进行二分法搜索,必须保证List是一个有序的，否则结果出错

__public void Clear()__
调用Array.Clear()

__public bool Contains(T item)__
遍历查找，时间复杂度O(n)

__public void CopyTo(T[] array)__ 
调用 Array.CopyTo 转为数组

__public T Find<Predicate<T\> match>__
__public List<T> FindAll(Predicate<T\> match)__
__public int FindIndex(Predicate<T\> match)__
__public int FindIndex(int startIndex , Predicate<T\> match)__
__public int FindIndex(int startIndex , int count , Predicate<T\> match)__
根据查找条件查找符合条件的进行返回(前--->后)

__public T FindLast(Predicate<T\> match)__
__public int FindLastIndex(Predicate<T\> match)__
__public int FindLastIndex(int startIndex, Predicate<T\> match)__
__public int FindLastIndex(int startIndex, int count, Predicate<T\> match)__
根据查找条件查找符合条件的进行返回(后--->前)

__public void ForEach(Action<T\> action)__
遍历List每一项,将每一项作为参数传递给action

__public List<T\> GetRange(int index, int count)__
获取某一个范围内的数据

__public int IndexOf(T item)__
__public int IndexOf(T item, int index)__
__public int IndexOf(T item, int index, int count)__
查找某个元素在List的索引（前->后）

__public int LastIndexOf(T item)__
__public int LastIndexOf(T item, int index)__
__public int LastIndexOf(T item, int index, int count)__
查找某个元素在List的索引（后->前）

__public void Insert(int index, T item)__
__public void InsertRange(int index, IEnumerable<T\> collection)__
插入元素到指定位置

__public bool Remove(T item)__
__public void RemoveAt(int index)__
__public void RemoveRange(int index, int count)__
__public int RemoveAll(Predicate<T\> match)__
根据条件移除某一或某一些数据

__public void Reverse()__
__public void Reverse(int index, int count)__
根据条件反转数据

__public void Sort()__
__public void Sort(IComparer<T\> comparer)__
__public void Sort(int index, int count, IComparer<T\> comparer)__
__public void Sort(Comparison<T\> comparison)__
根据条件对List进行排序

__public T[] ToArray()__
List--->Array

__public void TrimExcess()__
裁剪List,在确保List中元素不会增加之后,如果_size<0.9*Capcity,则进行裁剪

__public bool TrueForAll(Predicate<T\> match)__
List 中是否所有元素都满足一个条件match

### 扩展:
__显示实现接口方法__:实现接口时带上接口名,作用:如果是子类的实例指向接口的引用，则调用的就是该显示实现的接口方法
__隐式实现接口的方法__:常用的实现接口的一种方式,只要是该类的实例，调用的均为该类的方法

__契约式编程__:契约的思想：对一组表达式做真假判断,真，则遵守契约,假，则违反契约.
参考链接:
[花开花落_.NET 4.0 中的契约式编程](http://www.baidu.com)
常用的一些契约:
断言:
__public static void Assert(bool condition);__
__public static void Assert(bool condition, string userMessage);__
public static void DoAssert(int i)
{
    Contract.Assert(i >= 0,"i < 0");
    Console.WriteLine(i);
}
假设
__public static void Assume(bool condition);__
__public static void Assume(bool condition, string userMessage);__
PreConditions:
__public static void Requires(bool condition);__
__Requires<TException\>(bool condition, string userMessage)__
PostConditions:
__public static void Ensures(bool condition);__
__Ensures(bool condition, string userMessage);__

__C#内置5种委托__:
__public delegate void Action<in T\>(T obj);__
参数可选,无返回值的一种委托
__public delegate TResult Func<out TResult\>();__
参数可选,有返回值的一种委托
__public delegate int Comparison<in T\>(T x, T y);__
比较同种类型x,y的大小
__public delegate TOutput Converter<in TInput, out TOutput\>(TInput input);__
将一种类型转化为另一种类型，并返回
__public delegate bool Predicate<in T\>(T obj);__ 
定义一组条件，并确定传入的对象是否符合这些条件

