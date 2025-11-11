import type { MantineSize } from "@mantine/core";
import type {
  ComponentProps,
  FC,
  MouseEventHandler,
  ReactElement,
} from "react";
import React, { Children, cloneElement } from "react";
import { tv } from "tailwind-variants";

export interface IconButtonProps extends ComponentProps<"button"> {
  size?: MantineSize;
  children: ReactElement<ComponentProps<"svg">>;
  onClick: MouseEventHandler<HTMLButtonElement>;
}

const iconButtonVariants = tv({
  slots: {
    base: "appearance-none p-1 rounded-xs group/iconbutton inline-flex justify-center items-center",
    icon: "text-stone-600 group-hover/iconbutton:text-gray-400 group-active/iconbutton::text-gray-950 transition transition-50",
  },
  variants: {
    size: {
      xs: { icon: "size-3" },
      sm: { icon: "size-4" },
      md: { icon: "size-5" },
      lg: { icon: "size-6" },
      xl: { icon: "size-8" },
    },
  },
});

export const IconButton: FC<IconButtonProps> = ({
  children,
  size = "sm",
  className,
  ...props
}) => {
  const { base: buttonTailwind, icon: iconTailwind } = iconButtonVariants({
    size,
  });
  return (
    <button className={buttonTailwind({ className })} {...props}>
      {Children.map(children, (child) =>
        cloneElement(child, {
          className: iconTailwind({
            className: React.Children.only(child).props.className,
          }),
        })
      )}
    </button>
  );
};
