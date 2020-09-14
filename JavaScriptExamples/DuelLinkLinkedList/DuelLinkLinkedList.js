class LinkedListNode {
    constructor(value) {
        this.data = value;
        this.next = null;
        this.previous = null;
    }
}
class LinkedList {
    #count = 0;
    #start = null;
    #last = null;
    constructor() {
    }
    get Count() {
        return this.#count;
    }
    get Start() {
        return this.#start;
    }
    get Last() {
        return this.#last;
    }
    AddFirst(value) {
        let newNode = new LinkedListNode(value);
        if (this.#count == 0) {
            this.#start = newNode;
            this.#last = newNode;
            this.#count++;
            return;
        }
        newNode.next = this.#start;
        this.#start.previous = newNode;
        this.#start = newNode;
        this.#count++;
    }
    AddLast(value) {
        let newNode = new LinkedListNode(value);
        if (this.#count == 0) {
            this.#start = newNode;
            this.#last = newNode;
            this.#count++;
            return;
        }
        newNode.previous = this.#last;
        this.#last.next = newNode;
        this.#last = newNode;
        this.#count++;
    }
    AddAt(index, value) {
        if (index >= this.#count) return;
        let i = 0, temp = this.#start;
        for (; temp != null && i < index; i++, temp = temp.next);
        if (i == index) {
            let newNode = new LinkedListNode(value);
            newNode.next = temp.previous.next;
            newNode.previous = temp.previous;
            temp.previous.next = newNode;
            temp.previous = newNode;
            this.#count++;
        }
    }
    GetAt(index) {
        if (index >= this.#count) return -1;
        let i = 0, temp = this.#start;
        for (; temp != null && i < index; i++, temp = temp.next);
        if (i == index) {
            return temp.data;
        }
    }
    RemoveFirst() {
        if (this.#count < 1) return;
        this.#start = this.#start.next;
        this.#start.previous = null;
        this.#count--;
    }
    RemoveLast() {
        if (this.#count < 1) return;
        this.#last.previous.next = null;
        this.#last = this.#last.previous;
        this.#count--;
    }
    print() {
        let res = "List =>";
        for (let temp = this.#start; temp != null; temp = temp.next) {
            res += (" " + temp.data + " ");
        }
        return res
    }
}

let list = new LinkedList();
list.AddFirst(2);
list.AddLast(3);
list.AddFirst(1);
list.AddLast(5);
console.log(list.print())
console.log("Adding the number 4 at position 3");
list.AddAt(3,4);
console.log(list.print())
console.log("Get the value at position 2");
console.log("Value at position 2 => " + list.GetAt(2));
console.log("First value => "+ list.Start.data);
console.log("Last value => "+ list.Last.data);
console.log("Removed First");
list.RemoveFirst();
console.log("First value => "+ list.Start.data);
console.log("Removed Last");
list.RemoveLast();
console.log("Last value => "+ list.Last.data);
console.log(list.print())