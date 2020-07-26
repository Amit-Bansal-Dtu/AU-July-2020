let str = document.getElementById("str");
let arr = document.getElementById("arr");


//old style of writing js funciton
function Check_string(){
    let data = str.value;
    let RE1 = /^[h,n,d]ot.*[h,n,d]o+t$/;
    let second = document.getElementById("second");
    if(RE1.test(data)){
        second.innerText= "This is a valid String as it starts with hot, dot or not and ends with ho+t,do+t or no+t";
    }
    else{
        second.innerText = "This is an invalid string as it either doesn't starts with (hot, dot or not) or it doesn't ends with ho+t,do+t or no+t";
    }
}

var final_array = [];
//new style(ES6) of writing js function
const process_array = ()=>{
    let l1 = document.getElementById("1");
    let l2 = document.getElementById("2");
    let l3 = document.getElementById("3");
    let l4 = document.getElementById("4");
    final_array = [];
    let data = arr.value;
    let array = data.slice(1, data.length-1);
    let num_array = array.split(",");
    num_array.forEach(convert_to_int); 
    // 1.sorting the array
    final_array.sort((a, b)=> (a-b));
    l1.innerHTML = final_array;
    // 2. filter according to values >10
    final_array = final_array.filter((a)=>a>10);
    l2.innerText = final_array;
    // 3. add 1 to remaining array elements
    final_array.forEach((val, index)=>final_array[index] = val+1);
    l3.innerText = final_array;
    // 4. Now selecting only elements at indexes 1 to 4 inclusive.
    final_array = final_array.slice(1, 5);
    l4.innerText = final_array;
}

const convert_to_int = (val, index)=>{
    final_array.push(parseInt(val));
}