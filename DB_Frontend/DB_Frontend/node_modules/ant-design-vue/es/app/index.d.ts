import type { Plugin } from 'vue';
export declare const AppProps: () => {
    rootClassName: StringConstructor;
    message: {
        type: import("vue").PropType<import("../message/interface").ConfigOptions>;
        default: import("../message/interface").ConfigOptions;
    };
    notification: {
        type: import("vue").PropType<import("../notification/interface").NotificationConfig>;
        default: import("../notification/interface").NotificationConfig;
    };
};
declare const useApp: () => import("./context").useAppProps;
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<import("vue").ExtractPropTypes<{
        rootClassName: StringConstructor;
        message: {
            type: import("vue").PropType<import("../message/interface").ConfigOptions>;
            default: import("../message/interface").ConfigOptions;
        };
        notification: {
            type: import("vue").PropType<import("../notification/interface").NotificationConfig>;
            default: import("../notification/interface").NotificationConfig;
        };
    }>>, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<import("vue").ExtractPropTypes<{
        rootClassName: StringConstructor;
        message: {
            type: import("vue").PropType<import("../message/interface").ConfigOptions>;
            default: import("../message/interface").ConfigOptions;
        };
        notification: {
            type: import("vue").PropType<import("../notification/interface").NotificationConfig>;
            default: import("../notification/interface").NotificationConfig;
        };
    }>>, {
        message: import("../message/interface").ConfigOptions;
        notification: import("../notification/interface").NotificationConfig;
    }, true, {}, {}, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<import("vue").ExtractPropTypes<{
        rootClassName: StringConstructor;
        message: {
            type: import("vue").PropType<import("../message/interface").ConfigOptions>;
            default: import("../message/interface").ConfigOptions;
        };
        notification: {
            type: import("vue").PropType<import("../notification/interface").NotificationConfig>;
            default: import("../notification/interface").NotificationConfig;
        };
    }>>, () => import("../_util/type").VueNode, {}, {}, {}, {
        message: import("../message/interface").ConfigOptions;
        notification: import("../notification/interface").NotificationConfig;
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<import("vue").ExtractPropTypes<{
    rootClassName: StringConstructor;
    message: {
        type: import("vue").PropType<import("../message/interface").ConfigOptions>;
        default: import("../message/interface").ConfigOptions;
    };
    notification: {
        type: import("vue").PropType<import("../notification/interface").NotificationConfig>;
        default: import("../notification/interface").NotificationConfig;
    };
}>>, () => import("../_util/type").VueNode, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, {
    message: import("../message/interface").ConfigOptions;
    notification: import("../notification/interface").NotificationConfig;
}, {}, string, {}> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Plugin<any[]> & {
    readonly useApp: typeof useApp;
};
export default _default;
