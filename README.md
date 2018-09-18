# DotNet46

![进度](http://progressed.io/bar/0?title=progress) 

---
# 集合
---
集合名称 | 笔记
--------|--------
Array | :x:
List | :o:
Dictionary | :x:
Stack | :x:
Queue | :x:
LinkedList | :x:
 
---
### 1.List\<T\>
 **List是基于容量可变泛型列表.**

#### 主要内容
在List\<T\> 内部首先定义了一个泛型数组_items,所有对List的操作都会映射到这个数组上;

_defaultCapacity = 4; 这个是List默认的容量大小，这个字段作用于List中添加第一个元素时

List中有三个构造函数:
- List() 使用_emptyArray = new T[0];进行初始化items
- List(int capcity) 使用给定的 capcity 来初始化_items
- List(IEnumrable<T> collection) 使用实现了IEnumrable接口的集合来初始化List
特殊的是第三个构造器,调用c.CopyTo(_items,0)，collection中的元素全部复制到List中

**public int Capcity{get{...} set{...}}**  
value的值必须大于_size的值，然后新建一个容量为value的数组,再调用Array.Copy方法将将list中的_items 转移到 新建的数组中,最后再将数组赋值给_items  
**List中Capcity增加的规则**:如果不采用给定Capcity的话，则使用_emptyArray初始化_item,即初始化容量为0,在增加第一个元素之前，Capcity会增长为4，之后，每当准备突破容量临界时，容量进行2倍扩增  

**public int Count{get{...}}**  
获取的是List中实际数据的大小  

**public T this[int index]{get{...} set{...}}**  
 索引器  

**public void Add(T item)**   
先EnsureCapcity,在添加  

**public void AddRange(IEnumrable<T\> collection)**  
基本上也是也保证容量，再调用Array.Copy来进行增加  

**public void BinarySearch(T item)**  
调用Array.BinarySearch 进行二分法搜索,必须保证List是一个有序的，否则结果出错  

**public void Clear()**  
调用Array.Clear()  

**public bool Contains(T item)**  
遍历查找，时间复杂度O(n)  

**public void CopyTo(T[] array)**   
调用 Array.CopyTo 转为数组  

**public T Find<Predicate<T\> match>**   
**public List<T> FindAll(Predicate<T\> match)**  
**public int FindIndex(Predicate<T\> match)**  
**public int FindIndex(int startIndex , Predicate<T\> match)**  
**public int FindIndex(int startIndex , int count , Predicate<T\> match)**  
根据查找条件查找符合条件的进行返回(前--->后)  

**public T FindLast(Predicate<T\> match)**  
**public int FindLastIndex(Predicate<T\> match)**  
**public int FindLastIndex(int startIndex, Predicate<T\> match)**  
**public int FindLastIndex(int startIndex, int count, Predicate<T\> match)**  
根据查找条件查找符合条件的进行返回(后--->前)  

**public void ForEach(Action<T\> action)**  
遍历List每一项,将每一项作为参数传递给action  

**public List<T\> GetRange(int index, int count)**  
获取某一个范围内的数据  

**public int IndexOf(T item)**  
**public int IndexOf(T item, int index)**  
**public int IndexOf(T item, int index, int count)**  
查找某个元素在List的索引（前->后）  

**public int LastIndexOf(T item)**  
**public int LastIndexOf(T item, int index)**  
**public int LastIndexOf(T item, int index, int count)**  
查找某个元素在List的索引（后->前）  

**public void Insert(int index, T item)**  
**public void InsertRange(int index, IEnumerable<T\> collection)**  
插入元素到指定位置  

**public bool Remove(T item)**  
**public void RemoveAt(int index)**  
**public void RemoveRange(int index, int count)**  
**public int RemoveAll(Predicate<T\> match)**  
根据条件移除某一或某一些数据  

**public void Reverse()**  
**public void Reverse(int index, int count)**  
根据条件反转数据  

**public void Sort()**  
**public void Sort(IComparer<T\> comparer)**  
**public void Sort(int index, int count, IComparer<T\> comparer)**  
**public void Sort(Comparison<T\> comparison)**  
根据条件对List进行排序  

**public T[] ToArray()**  
List--->Array  

**public void TrimExcess()**  
裁剪List,在确保List中元素不会增加之后,如果_size<0.9*Capcity,则进行裁剪  

**public bool TrueForAll(Predicate<T\> match)**  
List 中是否所有元素都满足一个条件match  

### 扩展:
**显示实现接口方法**:实现接口时带上接口名,作用:如果是子类的实例指向接口的引用，则调用的就是该显示实现的接口方法  
**隐式实现接口的方法**:常用的实现接口的一种方式,只要是该类的实例，调用的均为该类的方法  

**契约式编程**:契约的思想：对一组表达式做真假判断,真，则遵守契约,假，则违反契约.  
参考链接:  
[花开花落_.NET 4.0 中的契约式编程](http://www.baidu.com)  
常用的一些契约:  
断言:  
**public static void Assert(bool condition);**  
**public static void Assert(bool condition, string userMessage);**  
public static void DoAssert(int i)  
{  
    Contract.Assert(i >= 0,"i < 0");  
    Console.WriteLine(i);  
}  
假设  
**public static void Assume(bool condition);**  
**public static void Assume(bool condition, string userMessage);**  
PreConditions:  
**public static void Requires(bool condition);**  
**Requires<TException\>(bool condition, string userMessage)**  
PostConditions:  
**public static void Ensures(bool condition);**  
**Ensures(bool condition, string userMessage);**  

**C#内置5种委托**:  
**public delegate void Action<in T\>(T obj);**  
参数可选,无返回值的一种委托  
**public delegate TResult Func<out TResult\>();**  
参数可选,有返回值的一种委托  
**public delegate int Comparison<in T\>(T x, T y);**  
比较同种类型x,y的大小  
**public delegate TOutput Converter<in TInput, out TOutput\>(TInput input);**  
将一种类型转化为另一种类型，并返回  
**public delegate bool Predicate<in T\>(T obj);**   
定义一组条件，并确定传入的对象是否符合这些条件  

---
# 与集合相关的几种接口的关系  

---
## 关系图

![与集合相关的几种接口的关系](https://github.com/SixGodZhang/Source/blob/master/Assets/someinterfaces.png)


## IEnumerable

```
   public interface IEnumerable
    {
        // Interfaces are not serializable
        // Returns an IEnumerator for this enumerable Object.  The enumerator provides
        // a simple way to access all the contents of a collection.
        [Pure]
        [DispId(-4)]
        IEnumerator GetEnumerator();
    }
```

## IEnumrable<T\>
泛型IEnumrable<T> 继承了IEnumrable,并屏蔽了GetEnumerator
```
    public interface IEnumerable<out T> : IEnumerable
    {
        // Returns an IEnumerator for this enumerable Object.  The enumerator provides
        // a simple way to access all the contents of a collection.
        /// <include file='doc\IEnumerable.uex' path='docs/doc[@for="IEnumerable.GetEnumerator"]/*' />
        new IEnumerator<T> GetEnumerator();
    }
```

## ICollection<T>
```
   public interface ICollection<T> : IEnumerable<T>
    {
        // Number of items in the collections.        
        int Count { get; }
 
        bool IsReadOnly { get; }
 
        void Add(T item);
 
        void Clear();
 
        bool Contains(T item); 
                
        // CopyTo copies a collection into an Array, starting at a particular
        // index into the array.
        // 
        void CopyTo(T[] array, int arrayIndex);
                
        //void CopyTo(int sourceIndex, T[] destinationArray, int destinationIndex, int count);
 
        bool Remove(T item);
    }
```

## ICollection
```
    public interface ICollection : IEnumerable
    {
        // Interfaces are not serialable
        // CopyTo copies a collection into an Array, starting at a particular
        // index into the array.
        // 
        void CopyTo(Array array, int index);
        
        // Number of items in the collections.
        int Count
        { get; }
        
        
        // SyncRoot will return an Object to use for synchronization 
        // (thread safety).  You can use this object in your code to take a
        // lock on the collection, even if this collection is a wrapper around
        // another collection.  The intent is to tunnel through to a real 
        // implementation of a collection, and use one of the internal objects
        // found in that code.
        //
        // In the absense of a static Synchronized method on a collection, 
        // the expected usage for SyncRoot would look like this:
        // 
        // ICollection col = ...
        // lock (col.SyncRoot) {
        //     // Some operation on the collection, which is now thread safe.
        //     // This may include multiple operations.
        // }
        // 
        // 
        // The system-provided collections have a static method called 
        // Synchronized which will create a thread-safe wrapper around the 
        // collection.  All access to the collection that you want to be 
        // thread-safe should go through that wrapper collection.  However, if
        // you need to do multiple calls on that collection (such as retrieving
        // two items, or checking the count then doing something), you should
        // NOT use our thread-safe wrapper since it only takes a lock for the
        // duration of a single method call.  Instead, use Monitor.Enter/Exit
        // or your language's equivalent to the C# lock keyword as mentioned 
        // above.
        // 
        // For collections with no publically available underlying store, the 
        // expected implementation is to simply return the this pointer.  Note 
        // that the this pointer may not be sufficient for collections that 
        // wrap other collections;  those should return the underlying 
        // collection's SyncRoot property.
        Object SyncRoot
        { get; }
            
        // Is this collection synchronized (i.e., thread-safe)?  If you want a 
        // thread-safe collection, you can use SyncRoot as an object to 
        // synchronize your collection with.  If you're using one of the 
        // collections in System.Collections, you could call the static 
        // Synchronized method to get a thread-safe wrapper around the 
        // underlying collection.
        bool IsSynchronized
        { get; }
    }
```
## 小结
    
