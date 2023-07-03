( black-pill-bb_03-jul-2023-1609z.fs )
( was: )
( black-pill-bb_03-jul-2023-1537z.fs )
( was: )
( black-pill-aa-05-mar-2021-b.fs )
( PC13 is Black Pill LED - it is blue )
( COLD HEX )
HEX
VARIABLE speed
55 speed C! ( speed C@ )
: emit EMIT ; : nop 1 DROP ; : drop DROP ;
: dup DUP ; : swap SWAP ; : over OVER ;
: or OR ; : and AND ; : rot ROT ;
: 2drop 2DROP ;
: 2dup 2DUP ; ( : not NOT ; )
: negate NEGATE ;
: abs ABS ; : max MAX ; : min MIN ; : base BASE ;
: depth DEPTH ; : here HERE ; : hex HEX ;
: decimal DECIMAL ; : key KEY ; : space SPACE ;
: spaces SPACES ; : type TYPE ; : cr CR ;
: char CHAR ; ( : preset PRESET ; )
: dump DUMP ;
: .s .S ; ( : see SEE ; )
: words WORDS ; : cold COLD ;
: <1?  ( n -- BOOL )
  dup 1 - 0< IF    drop -1 EXIT     THEN     drop 0 ;
: << ( n shifts -- )
  LSHIFT ;
: 2^ ( n -- )
  dup <1?  0< IF     drop 1 EXIT     THEN     1 swap << ;
: delstza 1 + DUP 6 = ; ( n+1 n+1 235 -- n+1 BOOL_equality )
: bbedelay 1 BEGIN delstza IF DROP EXIT THEN          AGAIN ;
: bbddelay 1 BEGIN delstza IF DROP EXIT THEN   1 DROP AGAIN ;
: bbcdelay 1 BEGIN delstza IF DROP EXIT THEN   1 DROP AGAIN ;
: bbbdelay 1 BEGIN delstza IF DROP EXIT THEN bbcdelay AGAIN ;
: bbadelay 1 BEGIN delstza IF DROP EXIT THEN bbbdelay AGAIN ;
: loofa    1 BEGIN delstza IF DROP EXIT THEN bbadelay AGAIN ;
: perlu 1 BEGIN 1 + DUP 9 = IF DROP EXIT THEN  loofa AGAIN ;
: delay    1 BEGIN delstza IF DROP EXIT THEN    perlu AGAIN ;
: bdelay   1 BEGIN delstza IF DROP EXIT THEN    delay AGAIN ;
: bdkdelay 1 BEGIN 1 + DUP 5 =
                           IF DROP EXIT THEN   bdelay AGAIN ;
: ldelay   1 BEGIN 1 + DUP 8 =
                           IF DROP EXIT THEN bdkdelay AGAIN ;
: finishmsg ." done." ; ( -- )
: RCC 40023800 ; ( -- addr ) ( p. 65 )
: RCC_AHB1ENR RCC 30 + ; ( -- addr ) ( 7.3.24 )
: RCC_APB2ENR RCC 44 + ; ( -- addr ) ( table 34 p 266 )
: GPIOCEN ( -- n ) 1 2 << ; ( gives '4' )
: RCC! ( -- )
  RCC_AHB1ENR @     GPIOCEN or     RCC_AHB1ENR ! ;
: GPIOC 40020800 ; ( -- addr )
: GPIOC_MODER GPIOC 0 + ; ( -- addr )
: GPIOC_MODER! ( n -- )
  GPIOC_MODER @     OR GPIOC_MODER !  ;
: OUTPUT ( n -- )
  D 1 - max E min     2 * 1 swap LSHIFT GPIOC_MODER! ;
: GPIOC_BSRR ( -- addr )
  GPIOC 18 + ; ( 18 right for all GPIOx is addrs offset )
: BSX 2^ ; ( n -- n )
: BRX 10 + 2^ ; ( n -- n )
: GPIOC_BSRR!  ( n -- )
  GPIOC_BSRR ! ;
: led D ;   (  PC13 onboard LED )
: led!  GPIOC_BSRR! ; ( n -- )
: off BSX led! ; ( n -- ) ( inverse logic on this GPIO )
: on BRX led! ; ( n -- )
: setupled ( -- )
  RCC! led OUTPUT led off ;
: blink ( n -- )
    led on     bdelay     led off     bdkdelay ;
: linit ( -- n )
  FFFFFF9D setupled     blink     blink     blink 
  led off blink ;
: nullemit 0 emit ;
: blinks ( n -- )
  BEGIN  ( ." here is begin " CR )
  1 - DUP   0 = IF DROP   blink delay  EXIT THEN
  blink delay AGAIN ;
: vers ." black-pill-bb_03-jul-2023-1609z.fs " CR ;
( blink blink blink blink )
( END_OF_FORTH_SOURCE_CODE )
