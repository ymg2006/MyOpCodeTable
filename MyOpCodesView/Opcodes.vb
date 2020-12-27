Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices
Module OpCodesExtention
    Private ReadOnly _table As New Dictionary(Of OpCode, String)
    Private Function GetDelegate(i As Integer) As Action
        Select Case i
            Case 0
                Return (Sub()
                            'OpCodes.Add, OpCodes.Add_Ovf, OpCodes.Add_Ovf_Un, OpCodes.And, OpCodes.Arglist, OpCodes.Beq, OpCodes.Beq_S, OpCodes.Bge, OpCodes.Bge_S
                            _table.Add(OpCodes.Add, "Adds two values and pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Add_Ovf, "Adds two integers, performs an overflow check, and pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Add_Ovf_Un, "Adds two unsigned integer values, performs an overflow check, and pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.And, "Computes the bitwise AND of two values and pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Arglist, "Returns an unmanaged pointer to the argument list of the current method")
                            _table.Add(OpCodes.Beq, "Transfers control to a target instruction if two values are equal")
                            _table.Add(OpCodes.Beq_S, "Transfers control to a target instruction (short form) if two values are equal")
                            _table.Add(OpCodes.Bge, "Transfers control to a target instruction if the first value is greater than or equal to the second value")
                            _table.Add(OpCodes.Bge_S, "Transfers control to a target instruction (short form) if the first value is greater than or equal to the second value")
                        End Sub)
            Case 1
                Return (Sub()
                            'OpCodes.Bge_Un, OpCodes.Bge_Un_S, OpCodes.Bgt, OpCodes.Bgt_S, OpCodes.Bgt_Un, OpCodes.Bgt_Un_S, OpCodes.Ble, OpCodes.Ble_S, OpCodes.Ble_Un
                            _table.Add(OpCodes.Bge_Un, "Transfers control to a target instruction if the first value is greater than the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Bge_Un_S, "Transfers control to a target instruction (short form) if the first value is greater than the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Bgt, "Transfers control to a target instruction if the first value is greater than the second value")
                            _table.Add(OpCodes.Bgt_S, "Transfers control to a target instruction (short form) if the first value is greater than the second value")
                            _table.Add(OpCodes.Bgt_Un, "Transfers control to a target instruction if the first value is greater than the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Bgt_Un_S, "Transfers control to a target instruction (short form) if the first value is greater than the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Ble, "Transfers control to a target instruction if the first value is less than or equal to the second value")
                            _table.Add(OpCodes.Ble_S, "Transfers control to a target instruction (short form) if the first value is less than or equal to the second value")
                            _table.Add(OpCodes.Ble_Un, "Transfers control to a target instruction if the first value is less than or equal to the second value, when comparing unsigned integer values or unordered float values")
                        End Sub)
            Case 2
                Return (Sub()
                            'OpCodes.Ble_Un_S, OpCodes.Blt, OpCodes.Blt_S, OpCodes.Blt_Un, OpCodes.Blt_Un_S, OpCodes.Bne_Un, OpCodes.Bne_Un_S, OpCodes.Box, OpCodes.Br 
                            _table.Add(OpCodes.Ble_Un_S, "Transfers control to a target instruction (short form) if the first value is less than or equal to the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Blt, "Transfers control to a target instruction if the first value is less than the second value")
                            _table.Add(OpCodes.Blt_S, "Transfers control to a target instruction (short form) if the first value is less than the second value")
                            _table.Add(OpCodes.Blt_Un, "Transfers control to a target instruction if the first value is less than the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Blt_Un_S, "Transfers control to a target instruction (short form) if the first value is less than the second value, when comparing unsigned integer values or unordered float values")
                            _table.Add(OpCodes.Bne_Un, "Transfers control to a target instruction when two unsigned integer values or unordered float values are not equal")
                            _table.Add(OpCodes.Bne_Un_S, "Transfers control to a target instruction (short form) when two unsigned integer values or unordered float values are not equal")
                            _table.Add(OpCodes.Box, "Converts a value type to an object reference (type O)")
                            _table.Add(OpCodes.Br, "Unconditionally transfers control to a target instruction")
                        End Sub)
            Case 3
                Return (Sub()
                            'OpCodes.Br_S, OpCodes.Break, OpCodes.Brfalse, OpCodes.Brfalse_S, OpCodes.Brtrue, OpCodes.Brtrue_S, OpCodes.Call, OpCodes.Calli, OpCodes.Callvirt
                            _table.Add(OpCodes.Br_S, "Unconditionally transfers control to a target instruction (short form)")
                            _table.Add(OpCodes.Break, "Signals the Common Language Infrastructure (CLI) to inform the debugger that a break point has been tripped")
                            _table.Add(OpCodes.Brfalse, "Transfers control to a target instruction if value is false, a null reference (Nothing in Visual Basic), or zero")
                            _table.Add(OpCodes.Brfalse_S, "Transfers control to a target instruction if value is false, a null reference, or zero")
                            _table.Add(OpCodes.Brtrue, "Transfers control to a target instruction if value is true, not null, or non-zero")
                            _table.Add(OpCodes.Brtrue_S, "Transfers control to a target instruction (short form) if value is true, not null, or non-zero")
                            _table.Add(OpCodes.Call, "Calls the method indicated by the passed method descriptor")
                            _table.Add(OpCodes.Calli, "Calls the method indicated on the evaluation stack (as a pointer to an entry point) with arguments described by a calling convention")
                            _table.Add(OpCodes.Callvirt, "Calls a late-bound method on an object, pushing the return value onto the evaluation stack")

                        End Sub)
            Case 4
                Return (Sub()
                            'OpCodes.Castclass, OpCodes.Ceq, OpCodes.Cgt, OpCodes.Cgt_Un, OpCodes.Ckfinite, OpCodes.Clt, OpCodes.Clt_Un, OpCodes.Constrained, OpCodes.Conv_I 
                            _table.Add(OpCodes.Castclass, "Attempts to cast an object passed by reference to the specified class")
                            _table.Add(OpCodes.Ceq, "Compares two values. If they are equal, the integer value 1 (int32) is pushed onto the evaluation stack; otherwise 0 (int32) is pushed onto the evaluation stack")
                            _table.Add(OpCodes.Cgt, "Compares two values. If the first value is greater than the second, the integer value 1 (int32) is pushed onto the evaluation stack; otherwise 0 (int32) is pushed onto the evaluation stack")
                            _table.Add(OpCodes.Cgt_Un, "Compares two unsigned or unordered values. If the first value is greater than the second, the integer value 1 (int32) is pushed onto the evaluation stack; otherwise 0 (int32) is pushed onto the evaluation stack")
                            _table.Add(OpCodes.Ckfinite, "Throws ArithmeticException if value is not a finite number")
                            _table.Add(OpCodes.Clt, "Compares two values. If the first value is less than the second, the integer value 1 (int32) is pushed onto the evaluation stack; otherwise 0 (int32) is pushed onto the evaluation stack")
                            _table.Add(OpCodes.Clt_Un, "Compares the unsigned or unordered values value1 and value2. If value1 is less than value2, then the integer value 1 (int32) is pushed onto the evaluation stack; otherwise 0 (int32) is pushed onto the evaluation stack")
                            _table.Add(OpCodes.Constrained, "Constrains the type on which a virtual method call is made")
                            _table.Add(OpCodes.Conv_I, "Converts the value on top of the evaluation stack to native int")

                        End Sub)
            Case 5
                Return (Sub()
                            'OpCodes.Conv_I1, OpCodes.Conv_I2, OpCodes.Conv_I4, OpCodes.Conv_I8, OpCodes.Conv_Ovf_I, OpCodes.Conv_Ovf_I_Un, OpCodes.Conv_Ovf_I1, OpCodes.Conv_Ovf_I1_Un, OpCodes.Conv_Ovf_I2
                            _table.Add(OpCodes.Conv_I1, "Converts the value on top of the evaluation stack to int8, then extends (pads) it to int32")
                            _table.Add(OpCodes.Conv_I2, "Converts the value on top of the evaluation stack to int16, then extends (pads) it to int32")
                            _table.Add(OpCodes.Conv_I4, "Converts the value on top of the evaluation stack to int32")
                            _table.Add(OpCodes.Conv_I8, "Converts the value on top of the evaluation stack to int64")
                            _table.Add(OpCodes.Conv_Ovf_I, "Converts the signed value on top of the evaluation stack to signed native int, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I_Un, "Converts the unsigned value on top of the evaluation stack to signed native int, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I1, "Converts the signed value on top of the evaluation stack to signed int8 and extends it to int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I1_Un, "Converts the unsigned value on top of the evaluation stack to signed int8 and extends it to int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I2, "Converts the signed value on top of the evaluation stack to signed int16 and extending it to int32, throwing OverflowException on overflow")

                        End Sub)
            Case 6
                Return (Sub()
                            'OpCodes.Conv_Ovf_I2_Un, OpCodes.Conv_Ovf_I4, OpCodes.Conv_Ovf_I4_Un, OpCodes.Conv_Ovf_I8, OpCodes.Conv_Ovf_I8_Un, OpCodes.Conv_Ovf_U, OpCodes.Conv_Ovf_U_Un, OpCodes.Conv_Ovf_U1, OpCodes.Conv_Ovf_U1_Un
                            _table.Add(OpCodes.Conv_Ovf_I2_Un, "Converts the unsigned value on top of the evaluation stack to signed int16 and extends it to int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I4, "Converts the signed value on top of the evaluation stack to signed int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I4_Un, "Converts the unsigned value on top of the evaluation stack to signed int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I8, "Converts the signed value on top of the evaluation stack to signed int64, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_I8_Un, "Converts the unsigned value on top of the evaluation stack to signed int64, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U, "Converts the signed value on top of the evaluation stack to unsigned native int, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U_Un, "Converts the unsigned value on top of the evaluation stack to unsigned native int, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U1, "Converts the signed value on top of the evaluation stack to unsigned int8 and extends it to int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U1_Un, "Converts the unsigned value on top of the evaluation stack to unsigned int8 and extends it to int32, throwing OverflowException on overflow")

                        End Sub)
            Case 7
                Return (Sub()
                            'OpCodes.Conv_Ovf_U2, OpCodes.Conv_Ovf_U2_Un, OpCodes.Conv_Ovf_U4, OpCodes.Conv_Ovf_U4_Un, OpCodes.Conv_Ovf_U8, OpCodes.Conv_Ovf_U8_Un, OpCodes.Conv_R_Un, OpCodes.Conv_R4, OpCodes.Conv_R8
                            _table.Add(OpCodes.Conv_Ovf_U2, "Converts the signed value on top of the evaluation stack to unsigned int16 and extends it to int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U2_Un, "Converts the unsigned value on top of the evaluation stack to unsigned int16 and extends it to int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U4, "Converts the signed value on top of the evaluation stack to unsigned int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U4_Un, "Converts the unsigned value on top of the evaluation stack to unsigned int32, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U8, "Converts the signed value on top of the evaluation stack to unsigned int64, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_Ovf_U8_Un, "Converts the unsigned value on top of the evaluation stack to unsigned int64, throwing OverflowException on overflow")
                            _table.Add(OpCodes.Conv_R_Un, "Converts the unsigned integer value on top of the evaluation stack to float32")
                            _table.Add(OpCodes.Conv_R4, "Converts the value on top of the evaluation stack to float32")
                            _table.Add(OpCodes.Conv_R8, "Converts the value on top of the evaluation stack to float64")

                        End Sub)
            Case 8
                Return (Sub()
                            'OpCodes.Conv_U, OpCodes.Conv_U1, OpCodes.Conv_U2, OpCodes.Conv_U4, OpCodes.Conv_U8, OpCodes.Cpblk, OpCodes.Cpobj, OpCodes.Div, OpCodes.Div_Un
                            _table.Add(OpCodes.Conv_U, "Converts the value on top of the evaluation stack to unsigned native int, and extends it to native int")
                            _table.Add(OpCodes.Conv_U1, "Converts the value on top of the evaluation stack to unsigned int8, and extends it to int32")
                            _table.Add(OpCodes.Conv_U2, "Converts the value on top of the evaluation stack to unsigned int16, and extends it to int32")
                            _table.Add(OpCodes.Conv_U4, "Converts the value on top of the evaluation stack to unsigned int32, and extends it to int32")
                            _table.Add(OpCodes.Conv_U8, "Converts the value on top of the evaluation stack to unsigned int64, and extends it to int64")
                            _table.Add(OpCodes.Cpblk, "Copies a specified number bytes from a source address to a destination address")
                            _table.Add(OpCodes.Cpobj, "Copies the value type located at the address of an object (type &,  or native int) to the address of the destination object (type &,  or native int)")
                            _table.Add(OpCodes.Div, "Divides two values and pushes the result as a floating-point (type F) or quotient (type int32) onto the evaluation stack")
                            _table.Add(OpCodes.Div_Un, "Divides two unsigned integer values and pushes the result (int32) onto the evaluation stack")

                        End Sub)
            Case 9
                Return (Sub()

                            'OpCodes.Dup, OpCodes.Endfilter, OpCodes.Endfinally, OpCodes.Initblk, OpCodes.Initobj, OpCodes.Isinst, OpCodes.Jmp, OpCodes.Ldarg, OpCodes.Ldarg_0
                            _table.Add(OpCodes.Dup, "Copies the current topmost value on the evaluation stack, and then pushes the copy onto the evaluation stack")
                            _table.Add(OpCodes.Endfilter, "Transfers control from the filter clause of an exception back to the Common Language Infrastructure (CLI) exception handler")
                            _table.Add(OpCodes.Endfinally, "Transfers control from the fault or finally clause of an exception block back to the Common Language Infrastructure (CLI) exception handler")
                            _table.Add(OpCodes.Initblk, "Initializes a specified block of memory at a specific address to a given size and initial value")
                            _table.Add(OpCodes.Initobj, "Initializes each field of the value type at a specified address to a null reference or a 0 of the appropriate primitive type")
                            _table.Add(OpCodes.Isinst, "Tests whether an object reference (type O) is an instance of a particular class")
                            _table.Add(OpCodes.Jmp, "Exits current method and jumps to specified method")
                            _table.Add(OpCodes.Ldarg, "Loads an argument (referenced by a specified index value) onto the stack")
                            _table.Add(OpCodes.Ldarg_0, "Loads the argument at index 0 onto the evaluation stack")

                        End Sub)
            Case 10
                Return (Sub()
                            'OpCodes.Ldarg_1, OpCodes.Ldarg_2, OpCodes.Ldarg_3, OpCodes.Ldarg_S, OpCodes.Ldarga, OpCodes.Ldarga_S, OpCodes.Ldc_I4, OpCodes.Ldc_I4_0, OpCodes.Ldc_I4_1
                            _table.Add(OpCodes.Ldarg_1, "Loads the argument at index 1 onto the evaluation stack")
                            _table.Add(OpCodes.Ldarg_2, "Loads the argument at index 2 onto the evaluation stack")
                            _table.Add(OpCodes.Ldarg_3, "Loads the argument at index 3 onto the evaluation stack")
                            _table.Add(OpCodes.Ldarg_S, "Loads the argument (referenced by a specified short form index) onto the evaluation stack")
                            _table.Add(OpCodes.Ldarga, "Load an argument address onto the evaluation stack")
                            _table.Add(OpCodes.Ldarga_S, "Load an argument address, in short form, onto the evaluation stack")
                            _table.Add(OpCodes.Ldc_I4, "Pushes a supplied value of type int32 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_0, "Pushes the integer value of 0 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_1, "Pushes the integer value of 1 onto the evaluation stack as an int32")

                        End Sub)
            Case 11
                Return (Sub()
                            'OpCodes.Ldc_I4_2, OpCodes.Ldc_I4_3, OpCodes.Ldc_I4_4, OpCodes.Ldc_I4_5, OpCodes.Ldc_I4_6, OpCodes.Ldc_I4_7, OpCodes.Ldc_I4_8, OpCodes.Ldc_I4_M1, OpCodes.Ldc_I4_S
                            _table.Add(OpCodes.Ldc_I4_2, "Pushes the integer value of 2 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_3, "Pushes the integer value of 3 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_4, "Pushes the integer value of 4 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_5, "Pushes the integer value of 5 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_6, "Pushes the integer value of 6 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_7, "Pushes the integer value of 7 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_8, "Pushes the integer value of 8 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_M1, "Pushes the integer value of -1 onto the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldc_I4_S, "Pushes the supplied int8 value onto the evaluation stack as an int32, short form")

                        End Sub)
            Case 12
                Return (Sub()
                            'OpCodes.Ldc_I8, OpCodes.Ldc_R4, OpCodes.Ldc_R8, OpCodes.Ldelem, OpCodes.Ldelem_I, OpCodes.Ldelem_I1, OpCodes.Ldelem_I2, OpCodes.Ldelem_I4, OpCodes.Ldelem_I8
                            _table.Add(OpCodes.Ldc_I8, "Pushes a supplied value of type int64 onto the evaluation stack as an int64")
                            _table.Add(OpCodes.Ldc_R4, "Pushes a supplied value of type float32 onto the evaluation stack as type F (float)")
                            _table.Add(OpCodes.Ldc_R8, "Pushes a supplied value of type float64 onto the evaluation stack as type F (float)")
                            _table.Add(OpCodes.Ldelem, "Loads the element at a specified array index onto the top of the evaluation stack as the type specified in the instruction")
                            _table.Add(OpCodes.Ldelem_I, "Loads the element with type native int at a specified array index onto the top of the evaluation stack as a native int")
                            _table.Add(OpCodes.Ldelem_I1, "Loads the element with type int8 at a specified array index onto the top of the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldelem_I2, "Loads the element with type int16 at a specified array index onto the top of the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldelem_I4, "Loads the element with type int32 at a specified array index onto the top of the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldelem_I8, "Loads the element with type int64 at a specified array index onto the top of the evaluation stack as an int64")

                        End Sub)
            Case 13
                Return (Sub()
                            'OpCodes.Ldelem_R4, OpCodes.Ldelem_R8, OpCodes.Ldelem_Ref, OpCodes.Ldelem_U1, OpCodes.Ldelem_U2, OpCodes.Ldelem_U4, OpCodes.Ldelema, OpCodes.Ldfld, OpCodes.Ldflda
                            _table.Add(OpCodes.Ldelem_R4, "Loads the element with type float32 at a specified array index onto the top of the evaluation stack as type F (float)")
                            _table.Add(OpCodes.Ldelem_R8, "Loads the element with type float64 at a specified array index onto the top of the evaluation stack as type F (float)")
                            _table.Add(OpCodes.Ldelem_Ref, "Loads the element containing an object reference at a specified array index onto the top of the evaluation stack as type O (object reference)")
                            _table.Add(OpCodes.Ldelem_U1, "Loads the element with type unsigned int8 at a specified array index onto the top of the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldelem_U2, "Loads the element with type unsigned int16 at a specified array index onto the top of the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldelem_U4, "Loads the element with type unsigned int32 at a specified array index onto the top of the evaluation stack as an int32")
                            _table.Add(OpCodes.Ldelema, "Loads the address of the array element at a specified array index onto the top of the evaluation stack as type & (managed pointer)")
                            _table.Add(OpCodes.Ldfld, "Finds the value of a field in the object whose reference is currently on the evaluation stack")
                            _table.Add(OpCodes.Ldflda, "Finds the address of a field in the object whose reference is currently on the evaluation stack")

                        End Sub)
            Case 14
                Return (Sub()
                            'OpCodes.Ldftn, OpCodes.Ldind_I, OpCodes.Ldind_I1, OpCodes.Ldind_I2, OpCodes.Ldind_I4, OpCodes.Ldind_I8, OpCodes.Ldind_R4, OpCodes.Ldind_R8, OpCodes.Ldind_Ref
                            _table.Add(OpCodes.Ldftn, "Pushes an unmanaged pointer (type native int) to the native code implementing a specific method onto the evaluation stack")
                            _table.Add(OpCodes.Ldind_I, "Loads a value of type native int as a native int onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_I1, "Loads a value of type int8 as an int32 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_I2, "Loads a value of type int16 as an int32 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_I4, "Loads a value of type int32 as an int32 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_I8, "Loads a value of type int64 as an int64 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_R4, "Loads a value of type float32 as a type F (float) onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_R8, "Loads a value of type float64 as a type F (float) onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_Ref, "Loads an object reference as a type O (object reference) onto the evaluation stack indirectly")

                        End Sub)
            Case 15
                Return (Sub()
                            'OpCodes.Ldind_U1, OpCodes.Ldind_U2, OpCodes.Ldind_U4, OpCodes.Ldlen, OpCodes.Ldloc, OpCodes.Ldloc_0, OpCodes.Ldloc_1, OpCodes.Ldloc_2, OpCodes.Ldloc_3
                            _table.Add(OpCodes.Ldind_U1, "Loads a value of type unsigned int8 as an int32 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_U2, "Loads a value of type unsigned int16 as an int32 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldind_U4, "Loads a value of type unsigned int32 as an int32 onto the evaluation stack indirectly")
                            _table.Add(OpCodes.Ldlen, "Pushes the number of elements of a zero-based, one-dimensional array onto the evaluation stack")
                            _table.Add(OpCodes.Ldloc, "Loads the local variable at a specific index onto the evaluation stack")
                            _table.Add(OpCodes.Ldloc_0, "Loads the local variable at index 0 onto the evaluation stack")
                            _table.Add(OpCodes.Ldloc_1, "Loads the local variable at index 1 onto the evaluation stack")
                            _table.Add(OpCodes.Ldloc_2, "Loads the local variable at index 2 onto the evaluation stack")
                            _table.Add(OpCodes.Ldloc_3, "Loads the local variable at index 3 onto the evaluation stack")

                        End Sub)
            Case 16
                Return (Sub()
                            'OpCodes.Ldloc_S, OpCodes.Ldloca, OpCodes.Ldloca_S, OpCodes.Ldnull, OpCodes.Ldobj, OpCodes.Ldsfld, OpCodes.Ldsflda, OpCodes.Ldstr, OpCodes.Ldtoken
                            _table.Add(OpCodes.Ldloc_S, "Loads the local variable at a specific index onto the evaluation stack, short form")
                            _table.Add(OpCodes.Ldloca, "Loads the address of the local variable at a specific index onto the evaluation stack")
                            _table.Add(OpCodes.Ldloca_S, "Loads the address of the local variable at a specific index onto the evaluation stack, short form")
                            _table.Add(OpCodes.Ldnull, "Pushes a null reference (type O) onto the evaluation stack")
                            _table.Add(OpCodes.Ldobj, "Copies the value type object pointed to by an address to the top of the evaluation stack")
                            _table.Add(OpCodes.Ldsfld, "Pushes the value of a static field onto the evaluation stack")
                            _table.Add(OpCodes.Ldsflda, "Pushes the address of a static field onto the evaluation stack")
                            _table.Add(OpCodes.Ldstr, "Pushes a new object reference to a string literal stored in the metadata")
                            _table.Add(OpCodes.Ldtoken, "Converts a metadata token to its runtime representation, pushing it onto the evaluation stack")

                        End Sub)
            Case 17
                Return (Sub()

                            'OpCodes.Ldvirtftn, OpCodes.Leave, OpCodes.Leave_S, OpCodes.Localloc, OpCodes.Mkrefany, OpCodes.Mul, OpCodes.Mul_Ovf, OpCodes.Mul_Ovf_Un, OpCodes.Neg
                            _table.Add(OpCodes.Ldvirtftn, "Pushes an unmanaged pointer (type native int) to the native code implementing a particular virtual method associated with a specified object onto the evaluation stack")
                            _table.Add(OpCodes.Leave, "Exits a protected region of code, unconditionally transferring control to a specific target instruction")
                            _table.Add(OpCodes.Leave_S, "Exits a protected region of code, unconditionally transferring control to a target instruction (short form)")
                            _table.Add(OpCodes.Localloc, "Allocates a certain number of bytes from the local dynamic memory pool and pushes the address (a transient pointer, type *) of the first allocated byte onto the evaluation stack")
                            _table.Add(OpCodes.Mkrefany, "Pushes a typed reference to an instance of a specific type onto the evaluation stack")
                            _table.Add(OpCodes.Mul, "Multiplies two values and pushes the result on the evaluation stack")
                            _table.Add(OpCodes.Mul_Ovf, "Multiplies two Integer values, performs an overflow check, And pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Mul_Ovf_Un, "Multiplies two unsigned Integer values, performs an overflow check, And pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Neg, "Negates a value And pushes the result onto the evaluation stack")

                        End Sub)
            Case 18
                Return (Sub()
                            'OpCodes.Newarr, OpCodes.Newobj, OpCodes.Nop, OpCodes.Not, OpCodes.Or, OpCodes.Pop, OpCodes.Prefix1, OpCodes.Prefix2, OpCodes.Prefix3
                            _table.Add(OpCodes.Newarr, "Pushes an Object reference To a New zero-based, one - dimensional array whose elements are of a specific type onto the evaluation stack")
                            _table.Add(OpCodes.Newobj, "Creates a New Object Or a New instance Of a value type, pushing an object reference (type O) onto the evaluation stack")
                            _table.Add(OpCodes.Nop, "Fills Space if opcodes are patched. No meaningful operation Is performed although a processing cycle can be consumed")
                            _table.Add(OpCodes.Not, "Computes the bitwise complement of the integer value on top of the stack And pushes the result onto the evaluation stack as the same type")
                            _table.Add(OpCodes.Or, "Compute the bitwise complement of the two integer values on top of the stack And pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Pop, "Removes the value currently on top of the evaluation stack")
                            _table.Add(OpCodes.Prefix1, "This Is a reserved instruction")
                            _table.Add(OpCodes.Prefix2, "This Is a reserved instruction")
                            _table.Add(OpCodes.Prefix3, "This is a reserved instruction")

                        End Sub)
            Case 19
                Return (Sub()
                            'OpCodes.Prefix4, OpCodes.Prefix5, OpCodes.Prefix6, OpCodes.Prefix7, OpCodes.Prefixref, OpCodes.Readonly, OpCodes.Refanytype, OpCodes.Refanyval, OpCodes.[Rem]
                            _table.Add(OpCodes.Prefix4, "This is a reserved instruction")
                            _table.Add(OpCodes.Prefix5, "This is a reserved instruction")
                            _table.Add(OpCodes.Prefix6, "This is a reserved instruction")
                            _table.Add(OpCodes.Prefix7, "This is a reserved instruction")
                            _table.Add(OpCodes.Prefixref, "This is a reserved instruction")
                            _table.Add(OpCodes.Readonly, "Specifies that the subsequent array address operation performs no type check at run time, and that it returns a managed pointer whose mutability is restricted")
                            _table.Add(OpCodes.Refanytype, "Retrieves the type token embedded in a typed reference")
                            _table.Add(OpCodes.Refanyval, "Retrieves the address (type &) embedded in a typed reference")
                            _table.Add(OpCodes.[Rem], "Divides two values and pushes the remainder onto the evaluation stack")

                        End Sub)
            Case 20
                Return (Sub()
                            'OpCodes.Rem_Un, OpCodes.Ret, OpCodes.Rethrow, OpCodes.Shl, OpCodes.Shr, OpCodes.Shr_Un, OpCodes.Sizeof, OpCodes.Starg, OpCodes.Starg_S
                            _table.Add(OpCodes.Rem_Un, "Divides two unsigned values And pushes the remainder onto the evaluation stack")
                            _table.Add(OpCodes.Ret, "Returns From the current method, pushing a return value (if present) From the callee's evaluation stack onto the caller's evaluation stack")
                            _table.Add(OpCodes.Rethrow, "Rethrows the current exception")
                            _table.Add(OpCodes.Shl, "Shifts an integer value to the left (in zeroes) by a specified number of bits, pushing the result onto the evaluation stack")
                            _table.Add(OpCodes.Shr, "Shifts an integer value (in sign) to the right by a specified number of bits, pushing the result onto the evaluation stack")
                            _table.Add(OpCodes.Shr_Un, "Shifts an unsigned integer value (in zeroes) to the right by a specified number of bits, pushing the result onto the evaluation stack")
                            _table.Add(OpCodes.Sizeof, "Pushes the size, in bytes, of a supplied value type onto the evaluation stack")
                            _table.Add(OpCodes.Starg, "Stores the value on top of the evaluation stack in the argument slot at a specified index")
                            _table.Add(OpCodes.Starg_S, "Stores the value On top Of the evaluation stack In the argument slot at a specified index, Short form")

                        End Sub)
            Case 21
                Return (Sub()
                            'OpCodes.Stelem, OpCodes.Stelem_I, OpCodes.Stelem_I1, OpCodes.Stelem_I2, OpCodes.Stelem_I4, OpCodes.Stelem_I8, OpCodes.Stelem_R4, OpCodes.Stelem_R8, OpCodes.Stelem_Ref
                            _table.Add(OpCodes.Stelem, "Replaces the array element at a given index with the value on the evaluation stack, whose type is specified in the instruction")
                            _table.Add(OpCodes.Stelem_I, "Replaces the array element at a given index with the native int value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_I1, "Replaces the array element at a given index with the int8 value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_I2, "Replaces the array element at a given index with the int16 value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_I4, "Replaces the array element at a given index with the int32 value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_I8, "Replaces the array element at a given index with the int64 value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_R4, "Replaces the array element at a given index with the float32 value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_R8, "Replaces the array element at a given index with the float64 value on the evaluation stack")
                            _table.Add(OpCodes.Stelem_Ref, "Replaces the array element at a given index with the object ref value (type O) on the evaluation stack")

                        End Sub)
            Case 22
                Return (Sub()
                            'OpCodes.Stfld, OpCodes.Stind_I, OpCodes.Stind_I1, OpCodes.Stind_I2, OpCodes.Stind_I4, OpCodes.Stind_I8, OpCodes.Stind_R4, OpCodes.Stind_R8, OpCodes.Stind_Ref
                            _table.Add(OpCodes.Stfld, "Replaces the value stored in the field of an object reference or pointer with a new value")
                            _table.Add(OpCodes.Stind_I, "Stores a value of type native int at a supplied address")
                            _table.Add(OpCodes.Stind_I1, "Stores a value of type int8 at a supplied address")
                            _table.Add(OpCodes.Stind_I2, "Stores a value of type int16 at a supplied address")
                            _table.Add(OpCodes.Stind_I4, "Stores a value of type int32 at a supplied address")
                            _table.Add(OpCodes.Stind_I8, "Stores a value of type int64 at a supplied address")
                            _table.Add(OpCodes.Stind_R4, "Stores a value of type float32 at a supplied address")
                            _table.Add(OpCodes.Stind_R8, "Stores a value of type float64 at a supplied address")
                            _table.Add(OpCodes.Stind_Ref, "Stores a object reference value at a supplied address")

                        End Sub)
            Case 23
                Return (Sub()
                            'OpCodes.Stloc, OpCodes.Stloc_0, OpCodes.Stloc_1, OpCodes.Stloc_2, OpCodes.Stloc_3, OpCodes.Stloc_S, OpCodes.Stobj, OpCodes.Stsfld, OpCodes.Sub
                            _table.Add(OpCodes.Stloc, "Pops the current value from the top of the evaluation stack and stores it in a the local variable list at a specified index")
                            _table.Add(OpCodes.Stloc_0, "Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 0")
                            _table.Add(OpCodes.Stloc_1, "Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 1")
                            _table.Add(OpCodes.Stloc_2, "Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 2")
                            _table.Add(OpCodes.Stloc_3, "Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 3")
                            _table.Add(OpCodes.Stloc_S, "Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index (short form)")
                            _table.Add(OpCodes.Stobj, "Copies a value of a specified type from the evaluation stack into a supplied memory address")
                            _table.Add(OpCodes.Stsfld, "Replaces the value of a static field with a value from the evaluation stack")
                            _table.Add(OpCodes.Sub, "Subtracts one value from another and pushes the result onto the evaluation stack")

                        End Sub)
            Case 24
                Return (Sub()
                            'OpCodes.Sub_Ovf, OpCodes.Sub_Ovf_Un, OpCodes.Switch, OpCodes.Tailcall, OpCodes.Throw, OpCodes.Unaligned, OpCodes.Unbox, OpCodes.Unbox_Any, OpCodes.Volatile, OpCodes.Xor
                            _table.Add(OpCodes.Sub_Ovf, "Subtracts one integer value from another, performs an overflow check, and pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Sub_Ovf_Un, "Subtracts one unsigned integer value from another, performs an overflow check, and pushes the result onto the evaluation stack")
                            _table.Add(OpCodes.Switch, "Implements a jump table")
                            _table.Add(OpCodes.Tailcall, "Performs a postfixed method call instruction such that the current method's stack frame is removed before the actual call instruction is executed")
                            _table.Add(OpCodes.Throw, "Throws the exception object currently on the evaluation stack")
                            _table.Add(OpCodes.Unaligned, "Indicates that an address currently atop the evaluation stack might not be aligned to the natural size of the immediately following ldind, stind, ldfld, stfld, ldobj, stobj, initblk, or cpblk instruction")
                            _table.Add(OpCodes.Unbox, "Converts the boxed representation of a value type to its unboxed form")
                            _table.Add(OpCodes.Unbox_Any, "Converts the boxed representation of a type specified in the instruction to its unboxed form")
                            _table.Add(OpCodes.Volatile, "Specifies that an address currently atop the evaluation stack might be volatile, and the results of reading that location cannot be cached or that multiple stores to that location cannot be suppressed")
                            _table.Add(OpCodes.Xor, "Computes the bitwise XOR of the top two values on the evaluation stack, pushing the result onto the evaluation stack")
                        End Sub)
        End Select
    End Function


    Private ReadOnly Property Table As Dictionary(Of OpCode, String)
        Get
            If _table.Count <= 0 Then
                For i = 0 To 24
                    Parallel.Invoke(GetDelegate(i))
                Next
                Table = _table
            Else
                Table = _table
            End If
        End Get
    End Property

    <Extension()>
    Public Function GetAll(ByVal OpCodeExt As OpCode) As Dictionary(Of OpCode, String)
        Return Table
    End Function

    Public Class MyOpcode
        Public Property Name As String
        Public Property Value As String
        Public Property Size As String
        Public Property Info As String
        Public Property OpCodeType As String
        Public Property FlowControl As String
        Public Property OperandType As String
        Public Property StackBehaviourPush As String
        Public Property StackBehaviourPop As String
    End Class
End Module
