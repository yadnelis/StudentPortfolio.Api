import type { TooltipProps as MTooltipProps } from "@mantine/core";
import { Tooltip as MTooltip } from "@mantine/core";
import type { FC } from "react";
import { cn } from "../utilities/cs";

interface TooltipProps extends Omit<MTooltipProps, "classNames"> {
  color?: "default" | "danger";
}

export const Tooltip: FC<TooltipProps> = ({
  children,
  className,
  arrowSize = 8,
  withArrow = true,
  openDelay = 500,
  variant = "default",
  ...rest
}) => {
  return (
    <MTooltip
      className={cn(className)}
      withArrow={withArrow}
      arrowSize={arrowSize}
      openDelay={openDelay}
      classNames={{
        tooltip: cn(
          " border border-slate-300 text-sm text-gray-800 bg-slate-100 shadow-sm p-2 rounded",
          {
            "border-vermilion-200 shadow-vermilion-100": variant === "danger",
          },
        ),
        arrow: cn("bg-slate-500", {
          "bg-vermilion-400": variant === "danger",
        }),
      }}
      {...rest}
    >
      {children}
    </MTooltip>
  );
};
