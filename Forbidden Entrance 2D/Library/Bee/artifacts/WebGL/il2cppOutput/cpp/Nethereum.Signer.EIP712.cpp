#include "pch-cpp.hpp"





template <typename R, typename T1, typename T2>
struct VirtualFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

struct IDictionary_2_tFCD351BF188FF5E6FF9C60DB0FB5F23709718F2A;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct MemberValueU5BU5D_tE64DEF14E2FB5DF8E579321E889361BD80AD547E;
struct ABIEncode_t95CFC96B6E0E5D79DC62FF6969A0768A6C90C5CD;
struct ECDSASignature_tA046F191FBB0BF15D9F0DC8F1BDCEE1C5B7C127C;
struct ECKey_t15179DA21C4FF3FC07AB170ED70B8D9BD23729BB;
struct Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436;
struct Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8;
struct EthECDSASignature_tB10E880040705856539FB98EFEEC6BF42FAD4E1F;
struct EthECKey_t42377CCE1B3D38D907F5BA978AE0DDF80536031A;
struct EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745;
struct MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A;
struct ParametersEncoder_tFBB4314DD829C12C931094E7B88E1323250A8F95;
struct SecureRandom_tBF5FEDF46DC08AF928159066688C4868ECE54076;
struct Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6;
struct String_t;
struct TypedDataRaw_t8FC56374E3DB3D1DD5FAF68BFCEB7CC1EEF21172;

IL2CPP_EXTERN_C RuntimeClass* Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C const RuntimeMethod* Eip712TypedDataSigner_EncodeTypedData_TisDomain_t690AAB15D2E0B6CC6A353DDA7728F54B75899E90_m5E1462A8E6953574F0569A07A254CF1F6DBCAFDA_RuntimeMethod_var;

struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t1785D7CF495BD71D0C5AC261DCAEA25FFC80E736 
{
};
struct Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436  : public RuntimeObject
{
	ABIEncode_t95CFC96B6E0E5D79DC62FF6969A0768A6C90C5CD* ____abiEncode;
	ParametersEncoder_tFBB4314DD829C12C931094E7B88E1323250A8F95* ____parametersEncoder;
};
struct Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8  : public RuntimeObject
{
	EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745* ____signer;
};
struct EthECDSASignature_tB10E880040705856539FB98EFEEC6BF42FAD4E1F  : public RuntimeObject
{
	ECDSASignature_tA046F191FBB0BF15D9F0DC8F1BDCEE1C5B7C127C* ___U3CECDSASignatureU3Ek__BackingField;
};
struct EthECKey_t42377CCE1B3D38D907F5BA978AE0DDF80536031A  : public RuntimeObject
{
	ECKey_t15179DA21C4FF3FC07AB170ED70B8D9BD23729BB* ____ecKey;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____publicKey;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____publicKeyCompressed;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____publicKeyNoPrefix;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____publicKeyNoPrefixCompressed;
	String_t* ____ethereumAddress;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____privateKey;
	String_t* ____privateKeyHex;
};
struct MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A  : public RuntimeObject
{
};
struct Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct TypedDataRaw_t8FC56374E3DB3D1DD5FAF68BFCEB7CC1EEF21172  : public RuntimeObject
{
	RuntimeObject* ___U3CTypesU3Ek__BackingField;
	String_t* ___U3CPrimaryTypeU3Ek__BackingField;
	MemberValueU5BU5D_tE64DEF14E2FB5DF8E579321E889361BD80AD547E* ___U3CMessageU3Ek__BackingField;
	MemberValueU5BU5D_tE64DEF14E2FB5DF8E579321E889361BD80AD547E* ___U3CDomainRawValuesU3Ek__BackingField;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745  : public MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A
{
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_StaticFields
{
	Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* ___U3CCurrentU3Ek__BackingField;
};
struct Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_StaticFields
{
	Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* ___U3CCurrentU3Ek__BackingField;
};
struct EthECKey_t42377CCE1B3D38D907F5BA978AE0DDF80536031A_StaticFields
{
	SecureRandom_tBF5FEDF46DC08AF928159066688C4868ECE54076* ___SecureRandom;
	uint8_t ___DEFAULT_PREFIX;
};
struct Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_StaticFields
{
	Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* ___U3CCurrentU3Ek__BackingField;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataSigner_EncodeTypedData_TisRuntimeObject_mADDBD32DFC42CCD10CDB28827220ABC96CA9B99F_gshared (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, String_t* ___0_json, String_t* ___1_messageKeySelector, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataSigner_EncodeTypedData_m15C64A77778B02F9A925092828532FD317AADB33 (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, String_t* ___0_json, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* Sha3Keccack_get_Current_mD6FFC538783F0A2C61503A659F979F136C302D91_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Sha3Keccack_CalculateHash_mE94324F2BF9D80A18C59A08CF5F0735B78ECAAA0 (Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR EthECDSASignature_tB10E880040705856539FB98EFEEC6BF42FAD4E1F* EthECKey_SignAndCalculateV_mED717951378503C254E2F51DA4C0DB29CDDEB7DB (EthECKey_t42377CCE1B3D38D907F5BA978AE0DDF80536031A* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_hash, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* EthECDSASignature_CreateStringSignature_m3495F324D764444CDF5EEDF2947DB91F4B26A6C0 (EthECDSASignature_tB10E880040705856539FB98EFEEC6BF42FAD4E1F* ___0_signature, const RuntimeMethod* method) ;
inline ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataSigner_EncodeTypedData_TisDomain_t690AAB15D2E0B6CC6A353DDA7728F54B75899E90_m5E1462A8E6953574F0569A07A254CF1F6DBCAFDA (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, String_t* ___0_json, String_t* ___1_messageKeySelector, const RuntimeMethod* method)
{
	return ((  ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* (*) (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8*, String_t*, String_t*, const RuntimeMethod*))Eip712TypedDataSigner_EncodeTypedData_TisRuntimeObject_mADDBD32DFC42CCD10CDB28827220ABC96CA9B99F_gshared)(__this, ___0_json, ___1_messageKeySelector, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MessageSigner__ctor_m67B284E6F6BABE98BB71F7B701A47D93F8DC3AC9 (MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* Eip712TypedDataEncoder_get_Current_m184699ED962D51A0E7A19DAD4C5D19558ED6CF97_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataEncoder_EncodeTypedDataRaw_m5F1BA3085EB59CD028A72D07388FF92E28A6CFF7 (Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* __this, TypedDataRaw_t8FC56374E3DB3D1DD5FAF68BFCEB7CC1EEF21172* ___0_typedData, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataEncoder_EncodeTypedData_m656CC1DF4ED698947535D964D1507B4CFC56CDCB (Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* __this, String_t* ___0_json, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EthereumMessageSigner__ctor_mF80566B1FA116EDE2BE4993DAF88D8B6DB493D0E (EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Eip712TypedDataSigner__ctor_m7768A14F01B00256A9768DEC1A7F4041729363EC (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* Eip712TypedDataSigner_get_Current_mB55F482DB4582AFD6BE5F9185AAC8CE986A15B43 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var);
		Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* L_0 = ((Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_StaticFields*)il2cpp_codegen_static_fields_for(Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var))->___U3CCurrentU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Eip712TypedDataSigner_SignTypedDataV4_m6FCA6F5CE3A4F44C81BEE26532D8FA198D8034E6 (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, String_t* ___0_json, EthECKey_t42377CCE1B3D38D907F5BA978AE0DDF80536031A* ___1_key, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	{
		String_t* L_0 = ___0_json;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1;
		L_1 = Eip712TypedDataSigner_EncodeTypedData_m15C64A77778B02F9A925092828532FD317AADB33(__this, L_0, NULL);
		V_0 = L_1;
		EthECKey_t42377CCE1B3D38D907F5BA978AE0DDF80536031A* L_2 = ___1_key;
		il2cpp_codegen_runtime_class_init_inline(Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* L_3;
		L_3 = Sha3Keccack_get_Current_mD6FFC538783F0A2C61503A659F979F136C302D91_inline(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5;
		L_5 = Sha3Keccack_CalculateHash_mE94324F2BF9D80A18C59A08CF5F0735B78ECAAA0(L_3, L_4, NULL);
		EthECDSASignature_tB10E880040705856539FB98EFEEC6BF42FAD4E1F* L_6;
		L_6 = EthECKey_SignAndCalculateV_mED717951378503C254E2F51DA4C0DB29CDDEB7DB(L_2, L_5, NULL);
		String_t* L_7;
		L_7 = EthECDSASignature_CreateStringSignature_m3495F324D764444CDF5EEDF2947DB91F4B26A6C0(L_6, NULL);
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Eip712TypedDataSigner_RecoverFromSignatureV4_m6370DE2F83E7B5D058B019397F3BEDA08AD99D22 (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, String_t* ___0_json, String_t* ___1_signature, String_t* ___2_messageKeySelector, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Eip712TypedDataSigner_EncodeTypedData_TisDomain_t690AAB15D2E0B6CC6A353DDA7728F54B75899E90_m5E1462A8E6953574F0569A07A254CF1F6DBCAFDA_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	{
		String_t* L_0 = ___0_json;
		String_t* L_1 = ___2_messageKeySelector;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2;
		L_2 = Eip712TypedDataSigner_EncodeTypedData_TisDomain_t690AAB15D2E0B6CC6A353DDA7728F54B75899E90_m5E1462A8E6953574F0569A07A254CF1F6DBCAFDA(__this, L_0, L_1, Eip712TypedDataSigner_EncodeTypedData_TisDomain_t690AAB15D2E0B6CC6A353DDA7728F54B75899E90_m5E1462A8E6953574F0569A07A254CF1F6DBCAFDA_RuntimeMethod_var);
		V_0 = L_2;
		MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A* L_3 = (MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A*)il2cpp_codegen_object_new(MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var);
		MessageSigner__ctor_m67B284E6F6BABE98BB71F7B701A47D93F8DC3AC9(L_3, NULL);
		il2cpp_codegen_runtime_class_init_inline(Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* L_4;
		L_4 = Sha3Keccack_get_Current_mD6FFC538783F0A2C61503A659F979F136C302D91_inline(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6;
		L_6 = Sha3Keccack_CalculateHash_mE94324F2BF9D80A18C59A08CF5F0735B78ECAAA0(L_4, L_5, NULL);
		String_t* L_7 = ___1_signature;
		String_t* L_8;
		L_8 = VirtualFuncInvoker2< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, String_t* >::Invoke(4, L_3, L_6, L_7);
		return L_8;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Eip712TypedDataSigner_RecoverFromSignatureV4_m777698A982DA7D666199080AC8D19E8C6CAFE7FC (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_encodedData, String_t* ___1_signature, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A* L_0 = (MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A*)il2cpp_codegen_object_new(MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var);
		MessageSigner__ctor_m67B284E6F6BABE98BB71F7B701A47D93F8DC3AC9(L_0, NULL);
		il2cpp_codegen_runtime_class_init_inline(Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* L_1;
		L_1 = Sha3Keccack_get_Current_mD6FFC538783F0A2C61503A659F979F136C302D91_inline(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___0_encodedData;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3;
		L_3 = Sha3Keccack_CalculateHash_mE94324F2BF9D80A18C59A08CF5F0735B78ECAAA0(L_1, L_2, NULL);
		String_t* L_4 = ___1_signature;
		String_t* L_5;
		L_5 = VirtualFuncInvoker2< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, String_t* >::Invoke(4, L_0, L_3, L_4);
		return L_5;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Eip712TypedDataSigner_RecoverFromSignatureHashV4_mFF1DC68BBF52ECB0DE9020621E10B42700EA32A6 (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_hash, String_t* ___1_signature, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A* L_0 = (MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A*)il2cpp_codegen_object_new(MessageSigner_t67479BD55534DFFA08709C3D4AFD03F5518D742A_il2cpp_TypeInfo_var);
		MessageSigner__ctor_m67B284E6F6BABE98BB71F7B701A47D93F8DC3AC9(L_0, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_hash;
		String_t* L_2 = ___1_signature;
		String_t* L_3;
		L_3 = VirtualFuncInvoker2< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, String_t* >::Invoke(4, L_0, L_1, L_2);
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataSigner_EncodeTypedDataRaw_m867F8D1FB62ECDE0CF1661DD9D8F3ABA01B240D0 (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, TypedDataRaw_t8FC56374E3DB3D1DD5FAF68BFCEB7CC1EEF21172* ___0_typedData, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var);
		Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* L_0;
		L_0 = Eip712TypedDataEncoder_get_Current_m184699ED962D51A0E7A19DAD4C5D19558ED6CF97_inline(NULL);
		TypedDataRaw_t8FC56374E3DB3D1DD5FAF68BFCEB7CC1EEF21172* L_1 = ___0_typedData;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2;
		L_2 = Eip712TypedDataEncoder_EncodeTypedDataRaw_m5F1BA3085EB59CD028A72D07388FF92E28A6CFF7(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* Eip712TypedDataSigner_EncodeTypedData_m15C64A77778B02F9A925092828532FD317AADB33 (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, String_t* ___0_json, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var);
		Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* L_0;
		L_0 = Eip712TypedDataEncoder_get_Current_m184699ED962D51A0E7A19DAD4C5D19558ED6CF97_inline(NULL);
		String_t* L_1 = ___0_json;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2;
		L_2 = Eip712TypedDataEncoder_EncodeTypedData_m656CC1DF4ED698947535D964D1507B4CFC56CDCB(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Eip712TypedDataSigner__ctor_m7768A14F01B00256A9768DEC1A7F4041729363EC (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745* L_0 = (EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745*)il2cpp_codegen_object_new(EthereumMessageSigner_tF481F829C030ABE15FB5B16F2A3E5441E9300745_il2cpp_TypeInfo_var);
		EthereumMessageSigner__ctor_mF80566B1FA116EDE2BE4993DAF88D8B6DB493D0E(L_0, NULL);
		__this->____signer = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____signer), (void*)L_0);
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Eip712TypedDataSigner__cctor_mE4E1EF8694DEF90A7D12FC9BB500D4327B176383 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8* L_0 = (Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8*)il2cpp_codegen_object_new(Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var);
		Eip712TypedDataSigner__ctor_m7768A14F01B00256A9768DEC1A7F4041729363EC(L_0, NULL);
		((Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_StaticFields*)il2cpp_codegen_static_fields_for(Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var))->___U3CCurrentU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_StaticFields*)il2cpp_codegen_static_fields_for(Eip712TypedDataSigner_tC2AE9959FBDA6D4F2E747A4109F3EA5FBC306EF8_il2cpp_TypeInfo_var))->___U3CCurrentU3Ek__BackingField), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* Sha3Keccack_get_Current_mD6FFC538783F0A2C61503A659F979F136C302D91_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var);
		Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6* L_0 = ((Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_StaticFields*)il2cpp_codegen_static_fields_for(Sha3Keccack_t8B3D17DEE632A97C106904848D7F8C61605425A6_il2cpp_TypeInfo_var))->___U3CCurrentU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* Eip712TypedDataEncoder_get_Current_m184699ED962D51A0E7A19DAD4C5D19558ED6CF97_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var);
		Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436* L_0 = ((Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_StaticFields*)il2cpp_codegen_static_fields_for(Eip712TypedDataEncoder_tD05CA96DEC12D23410A484CFE938C4C59FB8E436_il2cpp_TypeInfo_var))->___U3CCurrentU3Ek__BackingField;
		return L_0;
	}
}
