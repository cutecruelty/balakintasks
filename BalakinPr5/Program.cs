Console.WriteLine(@"
       .                .                    
       :""-.          .-"";                    
       |:`.`.__..__.'.';|                    
       || :-""      ""-; ||                    
       :;              :;                    
       /  .==.    .==.  \                    
      :      _.--._      ;                   
      ; .--.' `--' `.--. :                   
     :   __;`      ':__   ;                  
     ;  '  '-._:;_.-'  '  :                  
     '.       `--'       .'                  
      .""-._          _.-"".                   
    .'     """"------""""     `.                 
   /`-                    -'\                
  /`-                      -'\               
 :`-   .'              `.   -';              
 ;    /                  \    :              
:    :                    ;    ;             
;    ;                    :    :             
':_:.'                    '.;_;'             
   :_                      _;                
   ; ""-._                -"" :`-.     _.._    
   :_          ()          _;   ""--::__. `.  
    \""-                  -""/`._           :  
   .-""-.                 -""-.  """"--..____.'  
  /         .__  __.         \               
 : / ,       / """" \       . \           
  ""-:___..--""      ""--..___;-""

");

// task 1

int number = 0;

while (number < 3)
{
    Console.WriteLine($"while: {number}");
    number++;
}

do
{
    Console.WriteLine($"dowhile: {number}");
    number++;
} while (number < 3);

Console.WriteLine("while checks first (skips 3). dowhile executes first (runs 3 then stops).");

// task 2

Console.WriteLine("enter a num");
int i = int.Parse(Console.ReadLine());

int current = 1;

while (current < i)
{
    Console.WriteLine(current + "");
    current *= 2;
};

// task 3

Console.WriteLine("how many fibonacci numbres do oy uwant");

int count = int.Parse(Console.ReadLine());
int first = 0;
int second = 1;
int next;
int i0 = 0;

while (i0 < count)
{
    Console.Write(first + " ");
    next = first + second;
    first = second;
    second = next;
    i0++;
};
