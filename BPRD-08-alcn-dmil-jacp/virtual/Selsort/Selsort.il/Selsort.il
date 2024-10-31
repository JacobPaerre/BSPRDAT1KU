	.method public hidebysig static 
		void SelectionSort (
			int32[] arr
		) cil managed 
	{
		// Method begins at RVA 0x20cc
		// Header size: 12
		// Code size: 78 (0x4e)
		.maxstack 4
		.locals init (
			[0] int32,	# i
			[1] int32,	# least
			[2] int32,	# tmp
			[3] int32,	# j
			[4] bool,	# arr[j] < arr[least]
			[5] bool,	# j < arr.length
			[6] bool	# i < arr.length
		)

		IL_0000: nop
		IL_0001: ldc.i4.0					# load constant 0
		IL_0002: stloc.0					# store 0 as i (i = 0)
		IL_0003: br.s IL_0041				# start the for-loop
		// loop start (head: IL_0041)
			IL_0005: nop					
			IL_0006: ldloc.0				# load i
			IL_0007: stloc.1				# store the value of i (int least = i)
			IL_0008: ldloc.0				# load i again
			IL_0009: ldc.i4.1				# load constant 1
			IL_000a: add					# calculate i+1
			IL_000b: stloc.3				# store the value of i+1 (int j=i+1)
			IL_000c: br.s IL_0022			# start the next for-loop 
			// loop start (head: IL_0022)
				IL_000e: ldarg.0			# load the argument array (arr)
				IL_000f: ldloc.3			# load j
				IL_0010: ldelem.i4			# load arr[j]
				IL_0011: ldarg.0			# load the argument array (arr)
				IL_0012: ldloc.1			# load least
				IL_0013: ldelem.i4			# load arr[least]
				IL_0014: clt				# compare arr[j] < arr[least]
				IL_0016: stloc.s 4			# store the result of above as first local boolean 
				IL_0018: ldloc.s 4			# load the result
				IL_001a: brfalse.s IL_001e	# if false, skip the statement in the if statement (go to IL_001e)
											# if true:
				IL_001c: ldloc.3			# load j
				IL_001d: stloc.1			# store value of j at address of least (least = j)

				IL_001e: ldloc.3			# load j
				IL_001f: ldc.i4.1			# load constant 1
				IL_0020: add				# calculate j+1
				IL_0021: stloc.3			# store j+1 at address of j (j++)

				IL_0022: ldloc.3			# load j
				IL_0023: ldarg.0			# load the argument array (arr)
				IL_0024: ldlen				# load length of arr
				IL_0025: conv.i4			# convert to integer
				IL_0026: clt				# compare j < arr.length
				IL_0028: stloc.s 5			# store the result of above as second local boolean 
				IL_002a: ldloc.s 5			# load the result
				IL_002c: brtrue.s IL_000e	# if true, repeat the inner loop
			// end loop

			IL_002e: ldarg.0				# load the argument array (arr)
			IL_002f: ldloc.0				# load i
			IL_0030: ldelem.i4				# load arr[i]
			IL_0031: stloc.2				# store the result as second local variable (tmp = arr[i])
			IL_0032: ldarg.0				# load the argument array (arr)
			IL_0033: ldloc.0				# load i
			IL_0034: ldarg.0				# load the argument array (arr)
			IL_0035: ldloc.1				# load least
			IL_0036: ldelem.i4				# load arr[least]
			IL_0037: stelem.i4				# store result at arr[i] (arr[i] = arr[least])
			IL_0038: ldarg.0				# load the argument array (arr)
			IL_0039: ldloc.1				# load least
			IL_003a: ldloc.2				# load tmp
			IL_003b: stelem.i4				# store tmp at arr[least] (arr[least] = tmp) 
			IL_003c: nop
			IL_003d: ldloc.0				# load i
			IL_003e: ldc.i4.1				# load constant 1
			IL_003f: add					# calculate i+1
			IL_0040: stloc.0				# store i+1 at address of i (i++)

			IL_0041: ldloc.0				# load i
			IL_0042: ldarg.0				# load the argument array (arr)
			IL_0043: ldlen					# load length of arr
			IL_0044: conv.i4				# convert to integer
			IL_0045: clt					# compare i < arr.length
			IL_0047: stloc.s 6				# store the result of above as third local boolean 
			IL_0049: ldloc.s 6				# load the result
			IL_004b: brtrue.s IL_0005		# if true, repeat the loop (go to IL_0005)
		// end loop

		IL_004d: ret						# return to where function was called
	} // end of method Selsort::SelectionSort