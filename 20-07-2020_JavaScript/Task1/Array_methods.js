let arr1 = [1, 2, 3, 4, 5];
let arr2 = [6, 7, 8, 9, 10];
//concat() method
let arr3 = arr1.concat(arr2);

console.log(arr3);

function greater_than_5(data){
    return data>5;
}

function less_than_11(data){
    return data<11;
}
//every() method
console.log(arr3.every(greater_than_5));
console.log(arr3.every(less_than_11));

//filter() method
let arr4 = arr3.filter(greater_than_5);
console.log(arr4)


//forEach() method
arr4.forEach(print_array_data);

function print_array_data(data, index){
    console.log("At index-"+index+" value is: "+data);
}

//indexOf() method
arr4 = arr4.concat([7, 8, 10]);
let position = arr4.indexOf(7);
console.log(position);

//join() method
let arr5 = ["My", " name", " is", " Amit ", "Bansal."];
let str = arr5.join();

//lastIndexOf() method
position = arr4.lastIndexOf(7);
console.log(position);

//map() method
arr4 = arr4.map(mul_10);

function mul_10(val){
    return val*10;
}
console.log(arr4);

//pop() method
arr4.pop();
console.log(arr4);

//push() method
arr5.push("Hello", "Hi");
console.log(arr5);

//reduce() method
let sum = arr4.reduce(add_elements);

function add_elements(total, val){
    return total+val;
}
console.log(sum);

//reduceRight() method
let s1 = arr5.reduceRight(concat_elements);

function concat_elements(final, ele){
    return final+ele;
}

//reverse() method
arr5.reverse();
console.log(arr5);

//shift() method
arr5.shift();
console.log(arr5);

//slice() method
let arr6 = arr5.slice(1, 4);
console.log(arr6);

//some() method
console.log(arr4.some(greater_than_5));
console.log(arr4.some(less_than_11));

//toSource() method   --> this method is only working in mozilla browser
function fruit(color, shape, size){
    this.color = color;
    this.shape = shape;
    this.size = size;
}

let apple = new fruit("red", "round", "large");

console.log(apple.toSource());

//sort() method
arr5.sort();
console.log(arr5);

//splice() method
arr5.splice(1, 2, "how", "where");
console.log(arr5);

//toString() method
let str2 = arr5.toString();
console.log(str2);

//unshift() method
arr5.unshift("Who", "are");
console.log(arr5);




