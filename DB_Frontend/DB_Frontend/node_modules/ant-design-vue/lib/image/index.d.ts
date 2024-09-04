import type { ExtractPropTypes, ImgHTMLAttributes, Plugin } from 'vue';
import { imageProps } from '../vc-image/src/Image';
import PreviewGroup from './PreviewGroup';
export type ImageProps = Partial<ExtractPropTypes<ReturnType<typeof imageProps>> & Omit<ImgHTMLAttributes, 'placeholder' | 'onClick'>>;
export { imageProps };
export { PreviewGroup as ImagePreviewGroup };
declare const _default: {
    new (...args: any[]): import("vue").CreateComponentPublicInstance<Readonly<Partial<{
        preview: boolean | import("../vc-image").ImagePreviewType;
        wrapperStyle: import("vue").CSSProperties;
    } & {
        onClick?: import("../_util/EventInterface").MouseEventHandler;
        onError?: OnErrorEventHandlerNonNull;
        prefixCls?: string;
        wrapperClassName?: string;
        placeholder?: any;
        rootClassName?: string;
        src?: string;
        previewPrefixCls?: string;
        previewMask?: false | (() => any);
        fallback?: string;
    } & Omit<ImgHTMLAttributes, "onClick" | "placeholder">>>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Readonly<Partial<{
        preview: boolean | import("../vc-image").ImagePreviewType;
        wrapperStyle: import("vue").CSSProperties;
    } & {
        onClick?: import("../_util/EventInterface").MouseEventHandler;
        onError?: OnErrorEventHandlerNonNull;
        prefixCls?: string;
        wrapperClassName?: string;
        placeholder?: any;
        rootClassName?: string;
        src?: string;
        previewPrefixCls?: string;
        previewMask?: false | (() => any);
        fallback?: string;
    } & Omit<ImgHTMLAttributes, "onClick" | "placeholder">>>, {
        class?: any;
        placeholder?: any;
        inlist?: any;
    }, true, {}, {}, {
        P: {};
        B: {};
        D: {};
        C: {};
        M: {};
        Defaults: {};
    }, Readonly<Partial<{
        preview: boolean | import("../vc-image").ImagePreviewType;
        wrapperStyle: import("vue").CSSProperties;
    } & {
        onClick?: import("../_util/EventInterface").MouseEventHandler;
        onError?: OnErrorEventHandlerNonNull;
        prefixCls?: string;
        wrapperClassName?: string;
        placeholder?: any;
        rootClassName?: string;
        src?: string;
        previewPrefixCls?: string;
        previewMask?: false | (() => any);
        fallback?: string;
    } & Omit<ImgHTMLAttributes, "onClick" | "placeholder">>>, {}, {}, {}, {}, {
        class?: any;
        placeholder?: any;
        inlist?: any;
    }>;
    __isFragment?: never;
    __isTeleport?: never;
    __isSuspense?: never;
} & import("vue").ComponentOptionsBase<Readonly<Partial<{
    preview: boolean | import("../vc-image").ImagePreviewType;
    wrapperStyle: import("vue").CSSProperties;
} & {
    onClick?: import("../_util/EventInterface").MouseEventHandler;
    onError?: OnErrorEventHandlerNonNull;
    prefixCls?: string;
    wrapperClassName?: string;
    placeholder?: any;
    rootClassName?: string;
    src?: string;
    previewPrefixCls?: string;
    previewMask?: false | (() => any);
    fallback?: string;
} & Omit<ImgHTMLAttributes, "onClick" | "placeholder">>>, {}, {}, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, {
    class?: any;
    placeholder?: any;
    inlist?: any;
}, {}, string, {}> & import("vue").VNodeProps & import("vue").AllowedComponentProps & import("vue").ComponentCustomProps & Plugin<any[]> & {
    readonly PreviewGroup: typeof PreviewGroup;
};
export default _default;
