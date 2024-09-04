export declare const checkboxProps: {
    prefixCls: StringConstructor;
    name: StringConstructor;
    id: StringConstructor;
    type: StringConstructor;
    defaultChecked: {
        type: (BooleanConstructor | NumberConstructor)[];
        default: any;
    };
    checked: {
        type: (BooleanConstructor | NumberConstructor)[];
        default: any;
    };
    disabled: BooleanConstructor;
    tabindex: {
        type: (StringConstructor | NumberConstructor)[];
    };
    readonly: BooleanConstructor;
    autofocus: BooleanConstructor;
    value: import("vue-types").VueTypeValidableDef<any>;
    required: BooleanConstructor;
};
declare const _default: import("vue").DefineComponent<{
    prefixCls: StringConstructor;
    name: StringConstructor;
    id: StringConstructor;
    type: StringConstructor;
    defaultChecked: {
        type: (BooleanConstructor | NumberConstructor)[];
        default: any;
    };
    checked: {
        type: (BooleanConstructor | NumberConstructor)[];
        default: any;
    };
    disabled: BooleanConstructor;
    tabindex: {
        type: (StringConstructor | NumberConstructor)[];
    };
    readonly: BooleanConstructor;
    autofocus: BooleanConstructor;
    value: import("vue-types").VueTypeValidableDef<any>;
    required: BooleanConstructor;
}, () => import("vue/jsx-runtime").JSX.Element, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, ("change" | "click")[], "change" | "click", import("vue").PublicProps, Readonly<import("vue").ExtractPropTypes<{
    prefixCls: StringConstructor;
    name: StringConstructor;
    id: StringConstructor;
    type: StringConstructor;
    defaultChecked: {
        type: (BooleanConstructor | NumberConstructor)[];
        default: any;
    };
    checked: {
        type: (BooleanConstructor | NumberConstructor)[];
        default: any;
    };
    disabled: BooleanConstructor;
    tabindex: {
        type: (StringConstructor | NumberConstructor)[];
    };
    readonly: BooleanConstructor;
    autofocus: BooleanConstructor;
    value: import("vue-types").VueTypeValidableDef<any>;
    required: BooleanConstructor;
}>> & {
    onClick?: (...args: any[]) => any;
    onChange?: (...args: any[]) => any;
}, {
    required: boolean;
    disabled: boolean;
    autofocus: boolean;
    defaultChecked: number | boolean;
    checked: number | boolean;
    readonly: boolean;
}, {}>;
export default _default;
