main:
  add     $t0, $0, $zero
  addi    $t1, $zero, 1
  addi    $t3, $zero, 9

fib:
  beq     $t3, $0, finish
  add     $t2,$t1,$t0
  move    $t0, $t1
  move    $t1, $t2
  subi    $t3, $t3, 1
  j       fib
finish:
  addi    $a0, $t0, 0
  li      $v0, 1    # displays value in t0
  syscall     
  li      $v0, 10   #exit
  syscall     
