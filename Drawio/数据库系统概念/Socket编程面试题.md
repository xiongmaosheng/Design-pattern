# Socket编程面试题

**1、TCP和UDP的区别：**

1）TCP提供面向连接的传输，通信前要先建立连接（三次握手机制）；UDP提供无连接的传输，通信前不需要建立连接。

2）TCP提供可靠的传输（有序，无差错，不丢失，不重复）；UDP提供不可靠的传输。

3）TCP面向字节流的传输，因此它能将信息分割成组，并在接收端将其重组；UDP是面向数据报的传输，没有分组开销。

4）TCP提供拥塞控制和流量控制机制；UDP不提供拥塞控制和流量控制机制。



**2、流量控制和拥塞控制的实现机制：**

1）TCP采用大小可变的滑动窗口机制实现流量控制功能。窗口的大小是字节。在TCP报文段首部的窗口字段写入的数值就是当前给对方设置发送窗口的数据的上限。
在数据传输过程中，TCP提供了一种基于滑动窗口协议的流量控制机制，用接收端接收能力（缓冲区的容量）的大小来控制发送端发送的数据量。

2）采用滑动窗口机制还可对网络进行拥塞控制，将网络中的分组（TCP报文段作为其数据部分）数量维持在一定的数量之下，当超过该数值时，网络的性能会急剧恶化。传输层的拥塞控制有慢开始（Slow-Start）、拥塞避免（Congestion Avoidance）、快重传（Fast Retransmit）和快恢复（Fast Recovery）四种算法。
拥塞：　大量数据报涌入同一交换节点（如路由器），导致该节点资源耗尽而必须丢弃后面到达的数据报时，就是拥塞。



**3、重传机制：**

TCP每发送一个报文段，就设置一次定时器。只要定时器设置的重发时间到而还没有收到确认，就要重发这一报文段。 
TCP环境

报文往返时间不定、有很大差别
A、B在一个局域网络，往返时延很小
A、C在一个互联网内，往返时延很大
因此，A很难确定一个固定的、与B、C通信都适用的定时器时间

TCP采用了一种自适应算法。这种算法记录每一个报文段发出的时间，以及收到相应的确认报文段的时间。这两个时间之差就是报文段的往返时延。将各个报文段的往返时延样本加权平均，就得出报文段的平均往返时延T。


**4、滑动窗口机制：**
TCP 采用大小可变的滑动窗口进行流量控制。窗口大小的单位是字节。
在 TCP 报文段首部的窗口字段写入的数值就是当前给对方设置的发送窗口数值的上限。发送窗口在连接建立时由双方商定。但在通信的过程中，接收端可根据自己的资源情况，随时动态地调整对方的发送窗口上限值(可增大或减小)。



**5、多线程如何同步：**

临界区、互斥区、事件、信号量四种方式
临界区（Critical Section）、互斥量（Mutex）、信号量（Semaphore）、事件（Event）的区别
1）、临界区：通过对多线程的串行化来访问公共资源或一段代码，速度快，适合控制数据访问。在任意时刻只允许一个线程对共享资源进行访问，如果有多个线程试图访问公共资源，那么在有一个线程进入后，其他试图访问公共资源的线程将被挂起，并一直等到进入临界区的线程离开，临界区在被释放后，其他线程才可以抢占。
2）、互斥量：采用互斥对象机制。 只有拥有互斥对象的线程才有访问公共资源的权限，因为互斥对象只有一个，所以能保证公共资源不会同时被多个线程访问。互斥不仅能实现同一应用程序的公共资源安全共享，还能实现不同应用程序的公共资源安全共享 .互斥量比临界区复杂。因为使用互斥不仅仅能够在同一应用程序不同线程中实现资源的安全共享，而且可以在不同应用程序的线程之间实现对资源的安全共享。
3）、信号量：它允许多个线程在同一时刻访问同一资源，但是需要限制在同一时刻访问此资源的最大线程数目 .信号量对象对线程的同步方式与前面几种方法不同，信号允许多个线程同时使用共享资源，这与操作系统中的PV操作相同。它指出了同时访问共享资源的线程最大数目。它允许多个线程在同一时刻访问同一资源，但是需要限制在同一时刻访问此资源的最大线程数目。

PV操作及信号量的概念都是由荷兰科学家E.W.Dijkstra提出的。信号量S是一个整数，S大于等于零时代表可供并发进程使用的资源实体数，但S小于零时则表示正在等待使用共享资源的进程数。
　　 P操作申请资源：
　　（1）S减1；
　　（2）若S减1后仍大于等于零，则进程继续执行；
　　（3）若S减1后小于零，则该进程被阻塞后进入与该信号相对应的队列中，然后转入进程调度。
　　
　　V操作 释放资源：
　　（1）S加1；
　　（2）若相加结果大于零，则进程继续执行；
　　（3）若相加结果小于等于零，则从该信号的等待队列中唤醒一个等待进程，然后再返回原进程继续执行或转入进程调度。
4）、事 件： 通过通知操作的方式来保持线程的同步，还可以方便实现对多个线程的优先级比较的操作 .

总结：
　　1） 互斥量与临界区的作用非常相似，但互斥量是可以命名的，也就是说它可以跨越进程使用。所以创建互斥量需要的资源更多，所以如果只为了在进程内部是用的话使用临界区会带来速度上的优势并能够减少资源占用量。因为互斥量是跨进程的互斥量一旦被创建，就可以通过名字打开它。
　　2） 互斥量（Mutex），信号灯（Semaphore），事件（Event）都可以被跨越进程使用来进行同步数据操作，而其他的对象与数据同步操作无关，但对于进程和线程来讲，如果进程和线程在运行状态则为无信号状态，在退出后为有信号状态。所以可以使用WaitForSingleObject来等待进程和线程退出。
　　3） 通过互斥量可以指定资源被独占的方式使用，但如果有下面一种情况通过互斥量就无法处理，比如现在一位用户购买了一份三个并发访问许可的数据库系统，可以根据用户购买的访问许可数量来决定有多少个线程/进程能同时进行数据库操作，这时候如果利用互斥量就没有办法完成这个要求，信号灯对象可以说是一种资源计数器。



**信号与信号量的区别：**

 

1.信号：（signal）是一种处理异步事件的方式。信号时比较复杂的通信方式，用于通知接受进程有某种事件发生，除了用于进程外，还可以发送信号给进程本身。linux除了支持unix早期的信号语义函数，还支持语义符合posix.1标准的信号函数sigaction。

2.信号量：（Semaphore）进程间通信处理同步互斥的机制。是在多线程环境下使用的一种设施, 它负责协调各个线程, 以保证它们能够正确、合理的使用公共资源。





**6、进程和线程的区别：**

答：线程是指进程内的一个执行单元,也是进程内的可调度实体。与进程的区别:

(1)调度：线程作为调度和分配的基本单位，进程作为拥有资源的基本单位。

(2)并发性：不仅进程之间可以并发执行，同一个进程的多个线程之间也可并发执行。

(3)拥有资源：进程是拥有资源的一个独立单位，线程不拥有系统资源，但可以访问隶属于进程的资源.

(4)系统开销：在创建或撤消进程时，由于系统都要为之分配和回收资源，导致系统的开销明显大于创建或撤消线程时的开销。



**7、进程间通讯的方式有哪些，各有什么优缺点：**

1）管道：管道是一种半双工的通信方式，数据只能单向流动，而且只能在具有亲缘关系的进程之间使用。进程的亲缘关系通常是指父子进程关系。

2）有名管道（FIFO）：有名管道也是半双工的通信方式，但是允许在没有亲缘关系的进程之间使用，管道是先进先出的通信方式。

3）信号量：信号量是一个计数器，可以用来控制多个进程对共享资源的访问。它常作为一种锁机制，防止某进程正在访问共享资源时，其他进程也访问该资源。因此，主要作为进程间以及同一进程内不同线程之间的同步手段。

4）消息队列：消息队列是有消息的链表，存放在内核中并由消息队列标识符标识。消息队列克服了信号传递信息少、管道只能承载无格式字节流以及缓冲区大小受限等缺点。

5）信号 ( sinal ) ：信号是一种比较复杂的通信方式，用于通知接收进程某个事件已经发生。

6）共享内存( shared memory ) ：共享内存就是映射一段能被其他进程所访问的内存，这段共享内存由一个进程创建，但多个进程都可以访问。共享内存是最快的 IPC 方式，它是针对其他进程间通信方式运行效率低而专门设计的。它往往与其他通信机制，如信号量，配合使用，来实现进程间的同步和通信。
7）套接字( socket ) ：套接字也是一种进程间通信机制，与其他通信机制不同的是，它可用于不同机器间的进程通信。



**8、tcp连接建立的时候3次握手的具体过程，以及每一步原因：**

（1）  第一步：源主机A的TCP向主机B发出连接请求报文段，其首部中的SYN(同步)标志位应置为1，表示想与目标主机B进行通信，并发送一个同步序列号X(例：SEQ=100)进行同步，表明在后面传送数据时的第一个数据字节的序号是X＋1（即101）。SYN同步报文会指明客户端使用的端口以及TCP连接的初始序号。
（2）　　第二步：目标主机B的TCP收到连接请求报文段后，如同意，则发回确认。在确认报中应将ACK位和SYN位置1，表示客户端的请求被接受。确认号应为X＋1(图中为101)，同时也为自己选择一个序号Y。
（3）　　第三步：源主机A的TCP收到目标主机B的确认后要向目标主机B给出确认，其ACK置1，确认号为Y＋1，而自己的序号为X＋1。TCP的标准规定，SYN置1的报文段要消耗掉一个序号。
　　运行客户进程的源主机A的TCP通知上层应用进程，连接已经建立。当源主机A向目标主机B发送第一个数据报文段时，其序号仍为X＋1，因为前一个确认报文段并不消耗序号。
　　当运行服务进程的目标主机B的TCP收到源主机A的确认后，也通知其上层应用进程，连接已经建立。至此建立了一个全双工的连接。



**9、tcp断开连接的具体过程，其中每一步是为什么那么做：**

1)第一步：源主机A的应用进程先向其TCP发出连接释放请求，并且不再发送数据。TCP通知对方要释放从A到B这个方向的连接，将发往主机B的TCP报文段首部的终止比特FIN置1，其序号X等于前面已传送过的数据的最后一个字节的序号加1。

2)第二步：目标主机B的TCP收到释放连接通知后即发出确认，其序号为Y，确认号为X＋1，同时通知高层应用进程，这样，从A到B的连接就释放了，连接处于半关闭状态，相当于主机A向主机B说：“我已经没有数据要发送了。但如果还发送数据，我仍接收。”此后，主机B不再接收主机A发来的数据。但若主机B还有一些数据要发送主机A，则可以继续发送。主机A只要正确收到数据，仍应向主机B发送确认。

3)第三步：若主机B不再向主机A发送数据，其应用进程就通知TCP释放连接。主机B发出的连接释放报文段必须将终止比特FIN和确认比特ACK置1，并使其序号仍为Y，但还必须重复上次已发送过的ACK＝X＋1。

4) 第四步：主机A必须对此发出确认，将ACK置1，ACK＝Y＋1，而自己的序号是X＋1。这样才把从B到A的反方向的连接释放掉。主机A的TCP再向其应用进程报告，整个连接已经全部释放。



**10、tcp建立连接和断开连接的各种过程中的状态转换细节：**

客户端：主动打开SYN_SENT--->ESTABLISHED--->主动关闭FIN_WAIT_1--->FIN_WAIT_2--->TIME_WAIT

服务器端：LISTEN（被动打开）--->SYN_RCVD--->ESTABLISHED--->CLOSE_WAIT(被动关闭)--->LAST_ACK--->CLOSED



**11、epoll与select的区别：**

问题的引出，当需要读两个以上的I/O的时候，如果使用阻塞式的I/O，那么可能长时间的阻塞在一个描述符上面，另外的描述符虽然有数据但是不能读出来，这样实时性不能满足要求，大概的解决方案有以下几种：

1.使用多进程或者多线程，但是这种方法会造成程序的复杂，而且对与进程与线程的创建维护也需要很多的开销。（Apache服务器是用的子进程的方式，优点可以隔离用户）

2.用一个进程，但是使用非阻塞的I/O读取数据，当一个I/O不可读的时候立刻返回，检查下一个是否可读，这种形式的循环为轮询（polling），这种方法比较浪费CPU时间，因为大多数时间是不可读，但是仍花费时间不断反复执行read系统调用。

3.异步I/O（asynchronous I/O），当一个描述符准备好的时候用一个信号告诉进程，但是由于信号个数有限，多个描述符时不适用。

4.一种较好的方式为I/O多路转接（I/O multiplexing）（貌似也翻译多路复用），先构造一张有关描述符的列表（epoll中为队列），然后调用一个函数，直到这些描述符中的一个准备好时才返回，返回时告诉进程哪些I/O就绪。select和epoll这两个机制都是多路I/O机制的解决方案，select为POSIX标准中的，而epoll为Linux所特有的。

区别（epoll相对select优点）主要有三：

1.select的句柄数目受限，在linux/posix_types.h头文件有这样的声明：#define __FD_SETSIZE  1024 表示select最多同时监听1024个fd。而epoll没有，它的限制是最大的打开文件句柄数目。

2.epoll的最大好处是不会随着FD的数目增长而降低效率，在selec中采用轮询处理，其中的数据结构类似一个数组的数据结构，而epoll是维护一个队列，直接看队列是不是空就可以了。epoll只会对"活跃"的socket进行操作---这是因为在内核实现中epoll是根据每个fd上面的callback函数实现的。那么，只有"活跃"的socket才会主动的去调用 callback函数（把这个句柄加入队列），其他idle状态句柄则不会，在这点上，epoll实现了一个"伪"AIO。但是如果绝大部分的I/O都是“活跃的”，每个I/O端口使用率很高的话，epoll效率不一定比select高（可能是要维护队列复杂）。

3.使用mmap加速内核与用户空间的消息传递。无论是select,poll还是epoll都需要内核把FD消息通知给用户空间，如何避免不必要的内存拷贝就很重要，在这点上，epoll是通过内核于用户空间mmap同一块内存实现的。



**12、epoll中et和lt的区别与实现原理：**

epoll有2种工作方式:LT和ET。
LT(level triggered)是缺省的工作方式，并且同时支持block和no-block socket.在这种做法中，内核告诉你一个文件描述符是否就绪了，然后你可以对这个就绪的fd进行IO操作。如果你不作任何操作，内核还是会继续通知你 的，所以，这种模式编程出错误可能性要小一点。传统的select/poll都是这种模型的代表．
ET (edge-triggered)是高速工作方式，只支持no-block socket。在这种模式下，当描述符从未就绪变为就绪时，内核通过epoll告诉你。然后它会假设你知道文件描述符已经就绪，并且不会再为那个文件描述 符发送更多的就绪通知，直到你做了某些操作导致那个文件描述符不再为就绪状态了(比如，你在发送，接收或者接收请求，或者发送接收的数据少于一定量时导致 了一个EWOULDBLOCK 错误）。但是请注意，如果一直不对这个fd作IO操作(从而导致它再次变成未就绪)，内核不会发送更多的通知(only once),不过在TCP协议中，ET模式的加速效用仍需要更多的benchmark确认。
  epoll只有epoll_create,epoll_ctl,epoll_wait 3个系统调用。



**13、ThreadLocal与其它同步机制的比较：**

Threadlocal和其他所有的同步机制都是为了解决多线程中的对同一变量的访问冲突，在普通的同步机制中，是通过对对象加锁来实现多个线程对同一变量的安全访问的。这时该变量是多个线程共享的，使用这种同步机制需要很细致的分析在什么时候对变量进行读写，什么时候需要锁定某个对象，什么时候释放该对象的索等等。所有这些都是因为多个线程共享了该资源造成的。Threadlocal就从另一个角度来解决多线程的并发访问，Threadlocal会为每一个线程维护一个和该线程绑定的变量副本，从而隔离了多个线程的数据共享，每一个线程都拥有自己的变量副本，从而也就没有必要对该变量进行同步了。ThreadLocal提供了线程安全的共享对象，在编写多线程代码时，可以把不安全的变量封装进ThreadLocal。

总结：当然ThreadLocal并不能替代同步机制，两者面向的问题领域不同。同步机制是为了同步多个线程对相同资源的并发访问，是为了多个线程之间进行通信的有效方式；而ThreadLocal是隔离多个线程的数据共享，从根本上就不在多个线程之间共享资源（变量），这样当然不需要对多个线程进行同步了。所以，如果你需要进行多个线程之间进行通信，则使用同步机制；如果需要隔离多个线程之间的共享冲突，可以使用ThreadLocal，这将极大地简化你的程序，使程序更加易读、简洁。

 

**14、内存池、进程池、线程池：** 

自定义内存池的思想通过这个"池"字表露无疑，应用程序可以通过系统的内存分配调用预先一次性申请适当大小的内存作为一个内存池，之后应用程序自己对内存的分配和释放则可以通过这个内存池来完成。只有当内存池大小需要动态扩展时，才需要再调用系统的内存分配函数，其他时间对内存的一切操作都在应用程序的掌控之中。 应用程序自定义的内存池根据不同的适用场景又有不同的类型。 从线程安全的角度来分，内存池可以分为单线程内存池和多线程内存池。单线程内存池整个生命周期只被一个线程使用，因而不需要考虑互斥访问的问题；多线程内存池有可能被多个线程共享，因此则需要在每次分配和释放内存时加锁。相对而言，单线程内存池性能更高，而多线程内存池适用范围更广。
从内存池可分配内存单元大小来分，可以分为固定内存池和可变内存池。所谓固定内存池是指应用程序每次从内存池中分配出来的内存单元大小事先已经确定，是固定不变的；而可变内存池则每次分配的内存单元大小可以按需变化，应用范围更广，而性能比固定内存池要低。


 